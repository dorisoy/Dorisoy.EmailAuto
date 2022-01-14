using Dorisoy.EmailAuto.Model;
using Dorisoy.EmailAuto.Repositories.Interface;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Dorisoy.EmailAuto
{
    /// <summary>
    /// Setting Form
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class FrmSettings : Form
    {
        private readonly ISettingRepository _settingRepository;
        private SettingsModel _settingModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmSettings"/> class.
        /// </summary>
        /// <param name="settingRepository">The setting repository.</param>
        public FrmSettings(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
            InitializeComponent();
        }

        private async void FrmSettings_Load(object sender, EventArgs e)
        {
            _settingModel = await _settingRepository.Get();
            if (_settingModel != null)
            {
                txtEmailServer.Text = _settingModel.EmailServer;
                txtPassword.Text = _settingModel.Password;
                txtPort.Text = _settingModel.Port;
                chkSsl.Checked = _settingModel.Ssl;
                txtUsername.Text = _settingModel.UserName;
                TxtMiliseconds.Text = _settingModel.DelayMilliseconds.ToString();
            }
        }

        private async void BtnSaveEmailSetting_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                //var data = await _settingRepository.Get();
                if (_settingModel != null)
                {
                    _settingModel.EmailServer = txtEmailServer.Text.Trim();
                    _settingModel.Password = txtPassword.Text.Trim();
                    _settingModel.Port = txtPort.Text.Trim();
                    _settingModel.Ssl = chkSsl.Checked;
                    _settingModel.UserName = txtUsername.Text.Trim();
                    _settingModel.DelayMilliseconds = string.IsNullOrWhiteSpace(TxtMiliseconds.Text.Trim()) ? 0 : Convert.ToInt32(TxtMiliseconds.Text.Trim());
                    await _settingRepository.Edit(_settingModel);
                }
                else
                {
                    await _settingRepository.Add(new Model.SettingsModel()
                    {
                        EmailServer = txtEmailServer.Text.Trim(),
                        Password = txtPassword.Text.Trim(),
                        Port = txtPort.Text.Trim(),
                        Ssl = chkSsl.Checked,
                        UserName = txtUsername.Text.Trim(),
                        DelayMilliseconds = string.IsNullOrWhiteSpace(TxtMiliseconds.Text.Trim()) ? 0 : Convert.ToInt32(TxtMiliseconds.Text.Trim())
                    });
                }
                MessageBox.Show("配置保存成功.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void TxtEmailServer_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmailServer.Text))
            {
                e.Cancel = true;
                txtEmailServer.Focus();
                errorProviderEmailServer.SetError(txtEmailServer, "邮件地址不能为空");
            }
            else
            {
                e.Cancel = false;
                errorProviderEmailServer.SetError(txtEmailServer, "");
            }
        }

        private void TxtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                e.Cancel = true;
                txtUsername.Focus();
                errorProviderUserName.SetError(txtUsername, "账户名称不能为空");
            }
            else
            {
                e.Cancel = false;
                errorProviderUserName.SetError(txtUsername, "");
            }
        }

        private void TxtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProviderPassword.SetError(txtPassword, "密码不能为空");
            }
            else
            {
                e.Cancel = false;
                errorProviderPassword.SetError(txtPassword, "");
            }
        }
    }
}
