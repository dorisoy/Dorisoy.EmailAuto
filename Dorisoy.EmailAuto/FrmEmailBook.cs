using Dorisoy.EmailAuto.Model;
using Dorisoy.EmailAuto.Repositories.Interface;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dorisoy.EmailAuto
{
    /// <summary>
    /// Email Book From
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class FrmEmailBook : Form
    {
        private readonly IEmailBookRepository _emailBookRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmEmailBook"/> class.
        /// </summary>
        /// <param name="emailBookRepository">The email book repository.</param>
        public FrmEmailBook(IEmailBookRepository emailBookRepository)
        {
            _emailBookRepository = emailBookRepository;
            InitializeComponent();
            toolStripImport.Click += ToolStripImport_Click;
            toolStripMenuSelectAll.Click += ToolStripMenuSelectAll_Click;
            toolStripMenuISelectNone.Click += ToolStripMenuISelectNone_Click;
            toolStripButtonDelete.Click += ToolStripButtonDelete_Click;
        }

        private async void ToolStripButtonDelete_Click(object sender, EventArgs e)
        {
            var list = (from hasValue in dgvList.Rows.Cast<DataGridViewRow>()
                        where Convert.ToBoolean(hasValue.Cells["chkDelete"].Value) == true
                        select Convert.ToInt32(hasValue.Cells["EmailBookId"].Value)).ToList();

            if (list?.Count > 0)
            {
                await _emailBookRepository.Delete(list);
                await GetData();
            }
            else
            {
                MessageBox.Show("Please select at least one record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ToolStripMenuISelectNone_Click(object sender, EventArgs e)
        {
            SetCheckBoxInDataGrid(dgvList, 0, false);
        }

        private void ToolStripMenuSelectAll_Click(object sender, EventArgs e)
        {
            SetCheckBoxInDataGrid(dgvList, 0, true);
        }

        private void SetCheckBoxInDataGrid(DataGridView dgv, int pos, bool isChecked)
        {
            dgvList.ClearSelection();
            for (int i = 0; i < dgv.RowCount; i++)
            {
                dgv.Rows[i].DataGridView[pos, i].Value = isChecked;
            }
        }

        private async void ToolStripImport_Click(object sender, EventArgs e)
        {
            await ImportEmail();
        }

        private async void FrmEmailBook_Load(object sender, EventArgs e)
        {
            await GetData();
        }

        private async Task GetData()
        {
            var data = await _emailBookRepository.Get();
            dgvList.DataSource = null;
            dgvList.Rows.Clear();
            dgvList.Columns.Clear();
            dgvList.Refresh();
            dgvList.DataSource = data;
            Text = $"邮件簿 (总共 {data?.Count})";
            DataGridViewCheckBoxColumn buttonColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "删除",
                Name = "chkDelete",
                ValueType = typeof(bool),
                FalseValue = false,
                TrueValue = true
            };
            dgvList.Columns.Insert(0, buttonColumn);
            dgvList.Columns[1].ReadOnly = true;
            dgvList.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvList.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private async Task ImportEmail()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|CSV files (*.csv)|*.csv";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
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
                                    if (await _emailBookRepository.Exists(email) == false)
                                    {
                                        string name = values?.Length >= 2 ? values[1].Trim() : null;
                                        string option1 = values?.Length >= 3 ? values[2].Trim() : null;
                                        string option2 = values?.Length >= 4 ? values[3].Trim() : null;
                                        string option3 = values?.Length >= 5 ? values[4].Trim() : null;
                                        string option4 = values?.Length >= 6 ? values[5].Trim() : null;
                                        string option5 = values?.Length >= 7 ? values[6].Trim() : null;
                                        await _emailBookRepository.Add(new EmailBookModel()
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
                        await GetData();
                        MessageBox.Show($"Exists Email: {existsEmail}\nInvalid Email: {invalidEmail}\nValid Email: {(total - (existsEmail + invalidEmail))}\n----------------------\nTotal: {total}", "Summary", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                //return new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(email);
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
