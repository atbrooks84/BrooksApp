using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrooksApp.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Must be shorter than 200 characters")]
        public string Memo { get; set; }

        public double Amount { get; set; }
        public int BudgetId { get; set; }
        public int BankAccountId { get; set; }
        public int? BudgetItemId { get; set; }
        public string UserId { get; set; }
        public DateTime Created { get; set; }
        public int TypeId { get; set; }



        public virtual BankAccount BankAccount { get; set; }
        public virtual IEnumerable<Budget> Budget { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual IEnumerable<TransactionType> Type { get; set; }
        public virtual IEnumerable<BudgetItem> BudgetItem { get; set; }
    }
}