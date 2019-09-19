using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrooksApp.Models
{
    public class History
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int UserId { get; set; }
        public int BudgetId { get; set; }


        public virtual ApplicationUser User { get; set; }
        public virtual Budget Budget { get; set; }
    }
}