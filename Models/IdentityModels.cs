using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BrooksApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string DisplayName { get; set; }

        public string AvatarUrl { get; set; }

        public int HouseholdId { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<BrooksApp.Models.Household> Households { get; set; }

        public System.Data.Entity.DbSet<BrooksApp.Models.BankAccount> BankAccounts { get; set; }

        public System.Data.Entity.DbSet<BrooksApp.Models.AccountType> AccountTypes { get; set; }

        public System.Data.Entity.DbSet<BrooksApp.Models.Budget> Budgets { get; set; }

        public System.Data.Entity.DbSet<BrooksApp.Models.BudgetItem> BudgetItems { get; set; }

        public System.Data.Entity.DbSet<BrooksApp.Models.History> Histories { get; set; }

        public System.Data.Entity.DbSet<BrooksApp.Models.Invitation> Invitations { get; set; }

        public System.Data.Entity.DbSet<BrooksApp.Models.Notification> Notifications { get; set; }

        public System.Data.Entity.DbSet<BrooksApp.Models.Transaction> Transactions { get; set; }

        public System.Data.Entity.DbSet<BrooksApp.Models.TransactionType> TransactionTypes { get; set; }
    }
}