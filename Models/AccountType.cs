using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrooksApp.Models
{
    public class AccountType
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Must be shorter than 50 characters")]
        public string Name { get; set; }
        public string Description { get; set; }

        public string Type { get; set; }



    }
}