using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Vaseis
{
    /// <summary>
    /// Holds record of all actions
    /// </summary>
    public class LogDataModel
    {
        /// <summary>
        /// The id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The user's username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The action paragraph
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// The action paragraph
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// The date the action happened
        /// </summary>
        public DateTime When { get; set; } = DateTime.Now;

    }
}
