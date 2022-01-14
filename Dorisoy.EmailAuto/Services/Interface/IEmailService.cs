using Dorisoy.EmailAuto.Model;
using Dorisoy.EmailAuto.ViewModel;
using MimeKit;

namespace Dorisoy.EmailAuto.Services.Interface
{
    /// <summary>
    /// Email Service Interface
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Connects the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        MailKit.Net.Smtp.SmtpClient Connect(SettingsModel model);
        /// <summary>
        /// Gets the MIME message.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        MimeMessage GetMimeMessage(MimeMessageViewModel model);
        /// <summary>
        /// Sends the specified MIME message.
        /// </summary>
        /// <param name="mimeMessage">The MIME message.</param>
        /// <param name="smtp">The SMTP.</param>
        void Send(MimeMessage mimeMessage, MailKit.Net.Smtp.SmtpClient smtp);
        /// <summary>
        /// Disconnects the specified SMTP.
        /// </summary>
        /// <param name="smtp">The SMTP.</param>
        void Disconnect(MailKit.Net.Smtp.SmtpClient smtp);
    }
}
