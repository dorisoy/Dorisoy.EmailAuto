using Dorisoy.EmailAuto.Model;
using System.Collections.Generic;

namespace Dorisoy.EmailAuto.ViewModel
{
    /// <summary>
    /// Background Worker View Model
    /// </summary>
    public class BackgroundWorkerViewModel
    {
        /// <summary>
        /// Gets or sets the Email View Model list.
        /// </summary>
        /// <value>
        /// The Email View Model List
        /// </value>
        public List<EmailViewModel> List { get; set; } = new List<EmailViewModel>();

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        public SettingsModel Settings { get; set; }

        /// <summary>
        /// Gets or sets from.
        /// </summary>
        /// <value>
        /// From.
        /// </value>
        public string From { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public string Body { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is HTML content.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is HTML content; otherwise, <c>false</c>.
        /// </value>
        public bool IsHtmlContent { get; internal set; }

        /// <summary>
        /// Gets or sets the cc.
        /// </summary>
        /// <value>
        /// The cc.
        /// </value>
        public string CC { get; set; }

        /// <summary>
        /// Gets or sets the BCC.
        /// </summary>
        /// <value>
        /// The BCC.
        /// </value>
        public string BCC { get; set; }

        /// <summary>
        /// Gets or sets the attachment.
        /// </summary>
        /// <value>
        /// The attachment.
        /// </value>
        public List<string> Attachment { get; set; }
    }
}
