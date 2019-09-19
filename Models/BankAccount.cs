using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrooksApp.Models
{
    public class BankAccount
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Must be shorter than 50 characters")]
        public string Name { get; set; }
        public int Id { get; set; }
        public int StartingBalance { get; set; }
        public string Description { get; set; }
        public int CurrentBalance { get; set; }
        public DateTime Created { get; set; }
        public int HouseholdId { get; set; }
        [MaxLength(100, ErrorMessage = "Must be shorter than 100 characters")]
        public string Street { get; set; }
        [MaxLength(100, ErrorMessage = "Must be shorter than 100 characters")]
        public string City { get; set; }
        [MaxLength(30, ErrorMessage = "Must be shorter than 30 characters")]
        public string State { get; set; }

        //[MaxLength(10, ErrorMessage = "Not a valid zip code")]
        //[MinLength(5, ErrorMessage = "Not a valid zip code")]
        //public string Zip { get; set; }

        //[MaxLength(10, ErrorMessage = "Not a valid phone number")]
        //[MinLength(7, ErrorMessage = "Not a valid phone number")]
        //public int Phone { get; set; }
        public int AccountTypeId { get; set; }
        public string OwnerId { get; set; }



        public virtual Household Household { get; set; }
        public virtual AccountType AccountType { get; set; }
        public virtual ApplicationUser Owner { get; set; }
    }
}