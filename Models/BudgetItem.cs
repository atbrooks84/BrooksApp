using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrooksApp.Models
{
    public class BudgetItem
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Must be shorter than 50 characters")]
        public string Name { get; set; }
        public int Ammount { get; set; }
        public int BudgetId { get; set; }
       
        public DateTime Created { get; set; }
       



        public virtual Budget Budget { get; set; }
    }
}