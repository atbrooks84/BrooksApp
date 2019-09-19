using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrooksApp.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int RecipientId { get; set; }
        public int BudgetId { get; set; }


        public virtual Budget Budget { get; set; }
        public virtual ApplicationUser Recipient { get; set; }
    }
}