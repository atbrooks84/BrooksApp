using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrooksApp.Models
{
    public class TransactionType
    {
        public int Id { get; set; }

        public string Type { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Must be shorter than 50 characters")]
        public string Description { get; set; }

    }
}