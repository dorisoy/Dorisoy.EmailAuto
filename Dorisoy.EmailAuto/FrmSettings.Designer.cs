
namespace Dorisoy.EmailAuto
{
    partial class FrmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkSsl = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmailServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtMiliseconds = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSaveEmailSetting = new System.Windows.Forms.Button();
            this.errorProviderEmailServer = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderUserName = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderPassword = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMiliseconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEmailServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(725, 306);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtPassword);
            this.tabPage1.Controls.Add(this.txtUsername);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.chkSsl);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtPort);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtEmailServer);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(717, 269);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "邮件配置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(170, 156);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(479, 30);
            this.txtPassword.TabIndex = 10;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TxtPassword_Validating);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(170, 107);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(479, 30);
            this.txtUsername.TabIndex = 9;
            this.txtUsername.Validating += new System.ComponentModel.CancelEventHandler(this.TxtUsername_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(114, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "账户名";
            // 
            // chkSsl
            // 
            this.chkSsl.AutoSize = true;
            this.chkSsl.Checked = true;
            this.chkSsl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSsl.Location = new System.Drawing.Point(473, 65);
            this.chkSsl.Name = "chkSsl";
            this.chkSsl.Size = new System.Drawing.Size(22, 21);
            this.chkSsl.TabIndex = 6;
            this.chkSsl.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(392, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "启用SSL";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(170, 60);
            this.txtPort.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.txtPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(198, 30);
            this.txtPort.TabIndex = 4;
            this.txtPort.Value = new decimal(new int[] {
            465,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "端口";
            // 
            // txtEmailServer
            // 
            this.txtEmailServer.AutoCompleteCustomSource.AddRange(new string[] {
            "smtp.gmail.com\t",
            "smtp.live.com",
            "smtp.office365.com",
            "smtp.mail.yahoo.com",
            "plus.smtp.mail.yahoo.com",
            "smtp.mail.yahoo.co.uk",
            "smtp.mail.yahoo.com.au",
            "smtp.o2.ie",
            "smtp.o2.co.uk",
            "smtp.aol.com",
            "smtp.att.yahoo.com",
            "smtp.ntlworld.com",
            "pop3.btconnect.com",
            "mail.btopenworld.com",
            "mail.btinternet.com",
            "smtp.orange.net",
            "smtp.orange.co.uk",
            "smtp.wanadoo.co.uk",
            "mail.o2online.de",
            "securesmtp.t-online.de",
            "smtp.1and1.com",
            "smtp.1und1.de",
            "smtp.comcast.net",
            "outgoing.verizon.net",
            "outgoing.yahoo.verizon.net",
            "smtp.zoho.com",
            "smtp.mail.com",
            "smtp.gmx.com",
            "smtp.postoffice.net"});
            this.txtEmailServer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtEmailServer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtEmailServer.Location = new System.Drawing.Point(170, 16);
            this.txtEmailServer.Name = "txtEmailServer";
            this.txtEmailServer.Size = new System.Drawing.Size(479, 30);
            this.txtEmailServer.TabIndex = 2;
            this.txtEmailServer.Validating += new System.ComponentModel.CancelEventHandler(this.TxtEmailServer_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "服务器";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.TxtMiliseconds);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(717, 269);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "定时配置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Image = global::Dorisoy.EmailAuto.Properties.Resources.info;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(9, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(440, 29);
            this.label7.TabIndex = 2;
            this.label7.Text = "1000毫秒（ms）等于1秒（s）";
            // 
            // TxtMiliseconds
            // 
            this.TxtMiliseconds.Location = new System.Drawing.Point(9, 47);
            this.TxtMiliseconds.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.TxtMiliseconds.Name = "TxtMiliseconds";
            this.TxtMiliseconds.Size = new System.Drawing.Size(212, 30);
            this.TxtMiliseconds.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(262, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "电子邮件发送后延迟多少毫秒？";
            // 
            // btnSaveEmailSetting
            // 
            this.btnSaveEmailSetting.Location = new System.Drawing.Point(588, 312);
            this.btnSaveEmailSetting.Name = "btnSaveEmailSetting";
            this.btnSaveEmailSetting.Size = new System.Drawing.Size(123, 33);
            this.btnSaveEmailSetting.TabIndex = 0;
            this.btnSaveEmailSetting.Text = "保存";
            this.btnSaveEmailSetting.UseVisualStyleBackColor = true;
            this.btnSaveEmailSetting.Click += new System.EventHandler(this.BtnSaveEmailSetting_Click);
            // 
            // errorProviderEmailServer
            // 
            this.errorProviderEmailServer.ContainerControl = this;
            // 
            // errorProviderUserName
            // 
            this.errorProviderUserName.ContainerControl = this;
            // 
            // errorProviderPassword
            // 
            this.errorProviderPassword.ContainerControl = this;
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 353);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnSaveEmailSetting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSettings";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMiliseconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEmailServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPassword)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSaveEmailSetting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmailServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkSsl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.ErrorProvider errorProviderEmailServer;
        private System.Windows.Forms.ErrorProvider errorProviderUserName;
        private System.Windows.Forms.ErrorProvider errorProviderPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown TxtMiliseconds;
        private System.Windows.Forms.Label label7;
    }
}