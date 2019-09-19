using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrooksApp.Models
{
    public class Budget
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Must be shorter than 50 characters")]
        public string Name { get; set; }
        public int HouseholdId { get; set; }
        public DateTime Created { get; set; }

        public int Target { get; set; }
        public int Actual { get; set; }

        public string HouseholdName { get; set; }

        public ICollection<BudgetItem> BudgetItems { get; set; }



        public virtual Household Household { get; set; }

        public Budget()
            {
            this.BudgetItems = new HashSet<BudgetItem>();
            }


    }
}