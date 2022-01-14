using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dorisoy.EmailAuto.Model
{
    /// <summary>
    /// Settings Table
    /// </summary>
    [Table("Settings")]
    public class SettingsModel
    {
        /// <summary>Gets or sets the settings identifier.</summary>
        /// <value>The settings identifier.</value>
        [Key]
        [Required]
        public int SettingsId { get; set; }

        /// <summary>
        /// Gets or sets the email server.
        /// </summary>
        /// <value>
        /// The email server.
        /// </value>
        [StringLength(100)]
        public string EmailServer { get; set; }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        [StringLength(50)]
        public string Port { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SettingsModel"/> is SSL.
        /// </summary>
        /// <value>
        ///   <c>true</c> if SSL; otherwise, <c>false</c>.
        /// </value>
        [StringLength(50)]
        public bool Ssl { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        [StringLength(100)]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [StringLength(100)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the delay milliseconds.
        /// </summary>
        /// <value>
        /// The delay milliseconds.
        /// </value>
        public int DelayMilliseconds { get; set; } = 0;
    }
}
