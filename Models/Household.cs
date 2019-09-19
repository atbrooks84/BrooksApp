using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrooksApp.Models
{
    public class Household
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public string OwnerId { get; set; }

        public int UserId { get; set; }

        public string Code { get; set; }

        public ICollection<Budget> Budgets { get; set; }

        public Household()
        {
            this.Budgets = new HashSet<Budget>();
        }


    }

   
}
