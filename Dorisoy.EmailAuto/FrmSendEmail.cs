using Dorisoy.EmailAuto.Infrastructure.Helper;
using Dorisoy.EmailAuto.Model;
using Dorisoy.EmailAuto.Repositories.Interface;
using Dorisoy.EmailAuto.Services.Interface;
using Dorisoy.EmailAuto.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Dorisoy.EmailAuto
{
    /// <summary>
    /// Send Email Form
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class FrmSendEmail : Form
    {
        private readonly IEmailService _emailService;
        private readonly ISettingRepository _settingRepository;
        private BackgroundWorker _worker;
        private List<string> _files;
        private int _progress;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmSendEmail"/> class.
        /// </summary>
        /// <param name="emailService">The email service.</param>
        /// <param name="settingRepository">The setting repository.</param>
        public FrmSendEmail(IEmailService emailService, ISettingRepository settingRepository)
        {
            _emailService = emailService;
            _settingRepository = settingRepository;
            InitializeComponent();
            InitWorker();
        }

        private void InitWorker()
        {
            if (_worker != null)
            {
                _worker.Dispose();
            }
            _worker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            _worker.DoWork += DoWork;
            _worker.RunWorkerCompleted += RunWorkerCompleted;
            _worker.ProgressChanged += ProgressChanged;
            //_worker.RunWorkerAsync();
        }

        private void FrmSendEmail_Load(object sender, EventArgs e)
        {
            btnRemoveAttachment.Visible = false;
            btnPush.Enabled = false;
            btnStop.Enabled = false;
            btnAttachment.Text = $"附件";
            _progress = 0;
            _files = new List<string>();
            // Init GridView
            SetDataSource(new List<EmailViewModel>());
            txtLog.EnableContextMenu();
            txtEmailContent.EnableContextMenu();
        }

        #region Button Clicks

        private void BtnImportFromBook_Click(object sender, EventArgs e)
        {
            var child = (FrmImportEmailBook)Program.ServiceProvider.GetService((typeof(FrmImportEmailBook)));
            child.ShowDialog();
            var result = child.SelectedRows;
            if (result?.Count > 0)
            {
                List<EmailViewModel> emailViews = GetDataSource();
                if (emailViews == null) emailViews = new List<EmailViewModel>();
                foreach (DataGridViewRow item in result)
                {
                    var emailView = (EmailViewModel)item.DataBoundItem;
                    bool found = false;
                    found = emailViews.Where(p => p.Email == emailView.Email).Any();
                    if (found == false) emailViews.Add(emailView);
                }
                SetDataSource(emailViews);
            }
        }

        private void BtnImportFromCsv_Click(object sender, EventArgs e)
        {
            ImportFromCsv();
        }

        private async void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidatingForm())
                {
                    SettingsModel settingsModel = await _settingRepository.Get();
                    if (settingsModel == null)
                    {
                        MessageBox.Show($"请先设置邮件配置信息{Environment.NewLine}", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    btnStart.Enabled = false;
                    btnStart.BackColor = SystemColors.Control;
                    btnStart.ForeColor = SystemColors.ControlText;

                    btnPush.Enabled = true;
                    btnPush.BackColor = Color.Orange;
                    btnPush.ForeColor = Color.Black;

                    btnStop.Enabled = true;
                    btnStop.BackColor = Color.Firebrick;
                    btnStop.ForeColor = Color.White;


                    bool isHtmlContent = chkHtmlContent.Checked;
                    string bodyContent = isHtmlContent ? txtEmailContent.Text.Trim().Replace("\n", "<br/>") : txtEmailContent.Text.Trim();
                    List<EmailViewModel> emailViews = GetDataSource();
                    if (_progress > 0)
                    {
                        emailViews = emailViews.Skip(_progress).ToList();
                    }

                    BackgroundWorkerViewModel workerViewModel = new BackgroundWorkerViewModel
                    {
                        List = emailViews,
                        Settings = settingsModel,
                        Body = bodyContent,
                        From = txtEmailSender.Text.Trim(),
                        Subject = txtSubject.Text.Trim(),
                        IsHtmlContent = isHtmlContent,
                        CC = txtCC.Text.Trim(),
                        BCC = txtBCC.Text.Trim(),
                        Attachment = _files
                    };
                    _worker.RunWorkerAsync(workerViewModel);
                }
            }
            catch (Exception ex)
            {
                txtLog.Text = txtLog.Text.Insert(0, ex.Message);
            }
        }

        private void BtnPush_Click(object sender, EventArgs e)
        {
            // Cancel BackgroundWorker
            if (_worker.IsBusy)
            {
                _worker.CancelAsync();
                // Set Button Behavior
                btnStart.Enabled = true;
                btnStart.BackColor = Color.Green;
                btnStart.ForeColor = Color.White;
                btnStart.Text = $"重新开始";

                btnPush.Enabled = false;
                btnPush.BackColor = SystemColors.Control;
                btnPush.ForeColor = SystemColors.ControlText;

                btnStop.Enabled = true;
                btnStop.BackColor = Color.Firebrick;
                btnStop.ForeColor = Color.White;

                ColorizePattern();
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            // Cancel BackgroundWorker
            if (_worker.IsBusy)
            {
                _worker.CancelAsync();
            }
            ResetButton();
        }

        private void BtnAttachment_Click(object sender, EventArgs e)
        {
            GetAttachment();
        }

        private void BtnRemoveAttachment_Click(object sender, EventArgs e)
        {
            _files.Clear();
            btnAttachment.Text = "附件";
            btnRemoveAttachment.Visible = false;
            txtLog.Text = txtLog.Text.Insert(0, $"{Environment.NewLine}{DateTime.Now} 清理附加文件");
        }

        #endregion

        private void DgvRecipients_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvRecipients.ClearSelection();
            foreach (DataGridViewRow row in dgvRecipients.Rows)
                row.HeaderCell.Value = (row.Index + 1).ToString();
        }

        private void DgvRecipients_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgvRecipients.Columns["Email"].Index)
            {
                dgvRecipients.Rows[e.RowIndex].ErrorText = "";
                if (dgvRecipients.Rows[e.RowIndex].IsNewRow) { return; }
                if (IsValidEmail(Convert.ToString(e.FormattedValue).Trim()) == false)
                {
                    //e.Cancel = true;
                    dgvRecipients.Rows[e.RowIndex].ErrorText = "电子邮件必须是有效的";
                }
            }
        }

        private void TxtLog_TextChanged(object sender, EventArgs e)
        {
            //ColorizePattern();
        }

        private void ResetButton()
        {
            _progress = 0;
            // Set Button Behavior
            btnStart.Enabled = true;
            btnStart.BackColor = Color.Green;
            btnStart.ForeColor = Color.White;
            btnStart.Text = "Start";

            btnPush.Enabled = false;
            btnPush.BackColor = SystemColors.Control;
            btnPush.ForeColor = SystemColors.ControlText;

            btnStop.Enabled = false;
            btnStop.BackColor = SystemColors.Control;
            btnStop.ForeColor = SystemColors.ControlText;

            ColorizePattern();
        }

        private bool ValidatingForm()
        {
            if (string.IsNullOrWhiteSpace(txtEmailSender.Text))
            {
                MessageBox.Show("发件人不能为空", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (IsValidEmail(txtEmailSender.Text.Trim()) == false)
            {
                MessageBox.Show("请为发件人输入有效的邮件地址", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtSubject.Text))
            {
                MessageBox.Show("标题不能为空", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtEmailContent.Text))
            {
                MessageBox.Show("内容不能为空", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (dgvRecipients.Rows.Count <= 0)
            {
                MessageBox.Show("请导入邮件或从邮件簿中选择", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtCC.Text.Trim()) == false)
            {
                if (IsValidEmail(txtCC.Text.Trim()) == false)
                {
                    MessageBox.Show($"请输入有效的抄送邮件", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else if (string.IsNullOrWhiteSpace(txtBCC.Text.Trim()) == false)
            {
                if (IsValidEmail(txtBCC.Text.Trim()) == false)
                {
                    MessageBox.Show($"Please enter valid BCC email", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            List<EmailViewModel> emailViews = GetDataSource();
            if (emailViews?.Count <= 0)
            {
                MessageBox.Show($"请添加邮件收件人", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void ImportFromCsv()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|CSV files (*.csv)|*.csv";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    List<EmailViewModel> emailBooks = new List<EmailViewModel>();
                    List<EmailViewModel> dt = GetDataSource();
                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        //fileContent = reader.ReadToEnd();
                        int total = 0, invalidEmail = 0, existsEmail = 0;
                        while (!reader.EndOfStream)
                        {
                            total++;
                            var line = reader.ReadLine();
                            var values = line.Split(',');
                            if (values?.Length > 0)
                            {
                                string email = values[0].Trim();
                                bool isValidEmail = IsValidEmail(email);
                                if (isValidEmail)
                                {
                                    bool found = false;
                                    if (dt != null) found = dt.Where(p => p.Email == email).Any();
                                    if (found == false) found = emailBooks.Where(p => p.Email == email).Any();

                                    if (found == false)
                                    {
                                        string name = values?.Length >= 2 ? values[1].Trim() : null;
                                        string option1 = values?.Length >= 3 ? values[2].Trim() : null;
                                        string option2 = values?.Length >= 4 ? values[3].Trim() : null;
                                        string option3 = values?.Length >= 5 ? values[4].Trim() : null;
                                        string option4 = values?.Length >= 6 ? values[5].Trim() : null;
                                        string option5 = values?.Length >= 7 ? values[6].Trim() : null;
                                        emailBooks.Add(new EmailViewModel()
                                        {
                                            Email = email,
                                            Name = name,
                                            Option1 = option1,
                                            Option2 = option2,
                                            Option3 = option3,
                                            Option4 = option4,
                                            Option5 = option5
                                        });
                                    }
                                    else
                                    {
                                        existsEmail++;
                                    }
                                }
                                else
                                {
                                    invalidEmail++;
                                }
                            }
                        }
                        if (emailBooks.Count > 0)
                        {
                            if (dt == null)
                            {
                                SetDataSource(emailBooks);
                            }
                            else
                            {
                                dt.AddRange(emailBooks);
                                SetDataSource(dt);
                            }
                        }
                        MessageBox.Show($"Exists Email: {existsEmail}\nInvalid Email: {invalidEmail}\nValid Email: {(total - (existsEmail + invalidEmail))}\n----------------------\nTotal: {total}", "Summary", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private List<EmailViewModel> GetDataSource()
        {
            BindingSource bindingSource = (BindingSource)dgvRecipients.DataSource;
            if (bindingSource == null)
            {
                return new List<EmailViewModel>();
            }
            List<EmailViewModel> emailViews = (List<EmailViewModel>)bindingSource.DataSource;
            return emailViews;
        }

        private void SetDataSource(List<EmailViewModel> emailViews)
        {
            dgvRecipients.DataSource = null;
            dgvRecipients.DataSource = new BindingSource
            {
                DataSource = emailViews
            };
            dgvRecipients.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email)) return false;
                if (email.Contains(","))
                {
                    var emails = email.Split(",");
                    foreach (var item in emails)
                    {
                        if (IsValidEmail(item.Trim()) == false)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == email;
                }
            }
            catch
            {
                return false;
            }
        }

        private static string GetReplaceValue(EmailViewModel row, string content)
        {
            content = content.Replace("[Email]", row.Email);
            content = content.Replace("[Name]", row.Name);
            content = content.Replace("[Option1]", row.Option1);
            content = content.Replace("[Option2]", row.Option2);
            content = content.Replace("[Option3]", row.Option3);
            content = content.Replace("[Option4]", row.Option4);
            content = content.Replace("[Option5]", row.Option5);
            return content;
        }

        #region Background Worker

        void DoWork(object sender, DoWorkEventArgs e)
        {
            if (_worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                BackgroundWorkerViewModel arg = (BackgroundWorkerViewModel)e.Argument;
                int i = _progress;
                try
                {
                    MailKit.Net.Smtp.SmtpClient smtp = _emailService.Connect(arg.Settings);
                    foreach (EmailViewModel row in arg.List)
                    {
                        if (_worker.CancellationPending)
                        {
                            _emailService.Disconnect(smtp);
                            e.Cancel = true;
                            return;
                        }
                        i++;
                        if (IsValidEmail(row.Email.Trim()))
                        {

                            string body = GetReplaceValue(row, arg.Body);
                            string subject = GetReplaceValue(row, arg.Subject);
                            var mimeMessage = _emailService.GetMimeMessage(new MimeMessageViewModel()
                            {
                                From = arg.From,
                                To = row.Email,
                                CC = arg.CC,
                                BCC = arg.BCC,
                                Subject = subject,
                                Body = body,
                                IsHtmlContent = arg.IsHtmlContent,
                                Attachment = arg.Attachment
                            });
                            _emailService.Send(mimeMessage, smtp);
                            _worker.ReportProgress(i, $"{Environment.NewLine}{DateTime.Now} 发送 {row.Email} (行 no. {_progress + 1})");
                            if (arg.Settings?.DelayMilliseconds > 0)
                            {
                                System.Threading.Thread.Sleep(arg.Settings.DelayMilliseconds);
                            }
                        }
                        else
                        {
                            _worker.ReportProgress(i, $"{Environment.NewLine}{DateTime.Now} 无效邮件 {row.Email} (行 no. {_progress + 1})");
                        }
                    }
                    _emailService.Disconnect(smtp);
                }
                catch (Exception ex)
                {
                    _worker.ReportProgress(i, $"{Environment.NewLine}{DateTime.Now} Error {ex.Message}");
                }
            }
        }

        void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                // Display some message to the user that task has been
                // cancelled
                ColorizePattern();
            }
            else if (e.Error != null)
            {
                // Do something with the error
                txtLog.Text = txtLog.Text.Insert(0, $"{Environment.NewLine}{e.Error.Message}");
                ColorizePattern();
            }
            else
            {
                ResetButton();
            }
        }

        void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _progress = e.ProgressPercentage;
            txtLog.Text = txtLog.Text.Insert(0, (string)e.UserState);
        }

        #endregion

        private void ColorizePattern()
        {
            // Update lines to have extra length past length of window
            string[] linez = new string[txtLog.Lines.Length];
            for (int i = 0; i < txtLog.Lines.Length; i++)
            {
                linez[i] = txtLog.Lines[i] + new string(' ', 1000);
            }
            txtLog.Clear();
            txtLog.Lines = linez;

            for (int i = 0; i < txtLog.Lines.Length; i++)
            {
                int first = txtLog.GetFirstCharIndexFromLine(i);
                txtLog.Select(first, txtLog.Lines[i].Length);
                bool isError = txtLog.Lines[i].ContainsAny(new[] { " Error ", " Invalid Email " });
                bool isSent = txtLog.Lines[i].Contains(" Sent ");
                if (isError)
                {
                    txtLog.SelectionBackColor = Color.Transparent;
                    txtLog.SelectionColor = Color.Red;
                }
                else if (isSent)
                {
                    txtLog.SelectionBackColor = Color.Transparent;
                    txtLog.SelectionColor = Color.Green;
                }
            }
            txtLog.Select(0, 0);
        }

        private void GetAttachment()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog.FileNames?.Any() == true)
                    {
                        _files.AddRange(openFileDialog.FileNames.ToList());
                        txtLog.Text = txtLog.Text.Insert(0, $"{Environment.NewLine}{DateTime.Now} Attachment Files {string.Join(Environment.NewLine, openFileDialog.FileNames)}");
                        btnAttachment.Text = $"Attachment (File count {_files?.Count()})";
                    }
                }
            }
            if (_files?.Any() == true)
            {
                btnRemoveAttachment.Visible = true;
            }
        }

        private void chkHtmlContent_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
