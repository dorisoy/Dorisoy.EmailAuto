using Dorisoy.EmailAuto.Model;
using Dorisoy.EmailAuto.Services.Interface;
using Dorisoy.EmailAuto.ViewModel;
using MimeKit;
using MimeKit.Text;
using System;
using System.IO;
using System.Security.Authentication;

namespace Dorisoy.EmailAuto.Services
{
    /// <summary>
    /// Email Send Service
    /// </summary>
    /// <seealso cref="Dorisoy.EmailAuto.Services.Interface.IEmailService" />
    public class EmailService : IEmailService
    {
        /// <summary>
        /// Connects the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public MailKit.Net.Smtp.SmtpClient Connect(SettingsModel model)
        {
            var smtp = new MailKit.Net.Smtp.SmtpClient
            {
                ServerCertificateValidationCallback = (s, c, h, e) => true,
                CheckCertificateRevocation = false,
                // all versions of TLS
                SslProtocols = SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13
            };

            smtp.Connect(model.EmailServer, Convert.ToInt32(model.Port), model.Ssl);
            // Note: since you don't have an OAuth2 token, disable
            // the XOAUTH2 authentication mechanism.
            smtp.AuthenticationMechanisms.Remove("XOAUTH2");
            // Note: only needed if the SMTP server requires authentication
            smtp.Authenticate(model.UserName, model.Password);
            return smtp;
        }

        /// <summary>
        /// Gets the MIME message.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public MimeMessage GetMimeMessage(MimeMessageViewModel model)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(MailboxAddress.Parse(model.From));
            // Add To
            if (model.To.Contains(","))
            {
                InternetAddressList list = new InternetAddressList();
                foreach (var item in model.To.Split(","))
                {
                    list.Add(MailboxAddress.Parse(item.Trim()));
                }
                mimeMessage.To.AddRange(list);
            }
            else
            {
                mimeMessage.To.Add(MailboxAddress.Parse(model.To));
            }

            // Add CC
            if (!string.IsNullOrWhiteSpace(model.CC))
            {
                if (model.CC.Contains(","))
                {
                    InternetAddressList list = new InternetAddressList();
                    foreach (var item in model.CC.Split(","))
                    {
                        list.Add(MailboxAddress.Parse(item.Trim()));
                    }
                    mimeMessage.Cc.AddRange(list);
                }
                else
                {
                    mimeMessage.Cc.Add(MailboxAddress.Parse(model.CC));
                }
            }

            // Add Bcc
            if (!string.IsNullOrWhiteSpace(model.BCC))
            {
                if (model.BCC.Contains(","))
                {
                    InternetAddressList list = new InternetAddressList();
                    foreach (var item in model.BCC.Split(","))
                    {
                        list.Add(MailboxAddress.Parse(item.Trim()));
                    }
                    mimeMessage.Bcc.AddRange(list);
                }
                else
                {
                    mimeMessage.Bcc.Add(MailboxAddress.Parse(model.BCC));
                }
            }

            mimeMessage.Subject = model.Subject;

            var body = new TextPart(model.IsHtmlContent ? TextFormat.Html : TextFormat.Text) { Text = model.Body };

            // now create the multipart/mixed container to hold the message text and the
            // image attachment
            var multipart = new Multipart("mixed");
            multipart.Add(body);

            foreach (var item in model.Attachment)
            {
                var attachment = new MimePart()
                {
                    Content = new MimeContent(File.OpenRead(item)),
                    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                    ContentTransferEncoding = ContentEncoding.Base64,
                    FileName = Path.GetFileName(item)
                };
                multipart.Add(attachment);
            }

            // now set the multipart/mixed as the message body
            mimeMessage.Body = multipart;

            return mimeMessage;
        }

        /// <summary>
        /// Sends the specified MIME message.
        /// </summary>
        /// <param name="mimeMessage">The MIME message.</param>
        /// <param name="smtp">The SMTP.</param>
        public void Send(MimeMessage mimeMessage, MailKit.Net.Smtp.SmtpClient smtp) => smtp.Send(mimeMessage);

        /// <summary>
        /// Disconnects the specified SMTP.
        /// </summary>
        /// <param name="smtp">The SMTP.</param>
        public void Disconnect(MailKit.Net.Smtp.SmtpClient smtp) => smtp.Disconnect(true);
    }
}
