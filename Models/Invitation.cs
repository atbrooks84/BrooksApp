using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrooksApp.Models
{
    public class Invitation
    {
        public string SendToEmail { get; set; }
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public int SenderId { get; set; }
        public string Code { get; set; }
        public DateTime Created { get; set; }
        public int HouseholdId { get; set; }



        public virtual ApplicationUser Sender { get; set; }
        public virtual Household Household { get; set; }
    }
}