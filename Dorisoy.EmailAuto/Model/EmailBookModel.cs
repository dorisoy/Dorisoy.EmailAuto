using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dorisoy.EmailAuto.Model
{
    /// <summary>
    /// EmailBook Table
    /// </summary>
    [Table("EmailBook")]
    public class EmailBookModel
    {
        /// <summary>
        /// Gets or sets the email book identifier.
        /// </summary>
        /// <value>
        /// The email book identifier.
        /// </value>
        [Key]
        [Required]
        public int EmailBookId { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [StringLength(100)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the option1.
        /// </summary>
        /// <value>
        /// The option1.
        /// </value>
        public string Option1 { get; set; }

        /// <summary>
        /// Gets or sets the option2.
        /// </summary>
        /// <value>
        /// The option2.
        /// </value>
        public string Option2 { get; set; }

        /// <summary>
        /// Gets or sets the option3.
        /// </summary>
        /// <value>
        /// The option3.
        /// </value>
        public string Option3 { get; set; }

        /// <summary>
        /// Gets or sets the option4.
        /// </summary>
        /// <value>
        /// The option4.
        /// </value>
        public string Option4 { get; set; }

        /// <summary>
        /// Gets or sets the option5.
        /// </summary>
        /// <value>
        /// The option5.
        /// </value>
        public string Option5 { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
