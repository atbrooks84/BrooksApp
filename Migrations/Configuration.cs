namespace BrooksApp.Migrations
{
    using BrooksApp.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BrooksApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BrooksApp.Models.ApplicationDbContext";
        }

        protected override void Seed(BrooksApp.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            #region Roles Creation

            var roleManager = new RoleManager<IdentityRole>(
           new RoleStore<IdentityRole>(context));
            if (!context.Roles.Any(r => r.Name == "HeadOfHouse"))
            {
                roleManager.Create(new IdentityRole { Name = "HeadOfHouse" });
            }

            if (!context.Roles.Any(r => r.Name == "Member"))
            {
                roleManager.Create(new IdentityRole { Name = "Member" });
            }

            if (!context.Roles.Any(r => r.Name == "Lobby"))
            {
                roleManager.Create(new IdentityRole { Name = "Lobby" });
            }

            if (!context.Roles.Any(r => r.Name == "DemoHoH"))
            {
                roleManager.Create(new IdentityRole { Name = "DemoHoH" });
            }

            if (!context.Roles.Any(r => r.Name == "DemoMember"))
            {
                roleManager.Create(new IdentityRole { Name = "DemoMember" });
            }

            context.SaveChanges();
            #endregion

            #region Household Creation
            context.Households.AddOrUpdate(
                h=>h.Name,
                new Household { Name = "Brooks House", Description = "The Brooks Family", Created = DateTime.Now },
                new Household { Name = "Demo House", Description = "The Demo Family", Created = DateTime.Now },
                new Household { Name = "Lobby", Description = "The Lobby", Created = DateTime.Now }
                );

            context.SaveChanges();
            #endregion
            #region User Creation
            var brooksHouse = context.Households.FirstOrDefault(h => h.Name == "Brooks House").Id;
            var demoHouse = context.Households.FirstOrDefault(h => h.Name == "Demo House").Id;
            var lobby = context.Households.FirstOrDefault(h => h.Name == "Lobby").Id;


            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "atbrooks84@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "eldergod",
                    UserName = "atbrooks84@gmail.com",
                    Email = "atbrooks84@gmail.com",
                    FirstName = "Adam",
                    LastName = "Brooks",
                    DisplayName = "Ned",
                    AvatarUrl = "/Avatars/orisalogo.jpg",
                    HouseholdId= brooksHouse
                }, "Abc&123!");
            }

            if (!context.Users.Any(u => u.Email == "lauragrafphoto@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "wife",
                    UserName = "lauragrafphoto@gmail.com",
                    Email = "lauragrafphoto@gmail.com",
                    FirstName = "Laura",
                    LastName = "Brooks",
                    DisplayName = "Ducky",
                    AvatarUrl = "/Avatars/rubberduck.jpg",
                    HouseholdId = brooksHouse
                }, "Abc&123!");
            }

            if (!context.Users.Any(u => u.Email == "sprite@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "thedog",
                    UserName = "sprite@mailinator.com",
                    Email = "sprite@mailinator.com",
                    FirstName = "Sprite",
                    LastName = "Brooks",
                    DisplayName = "The Dog",
                    AvatarUrl = "/Avatars/sprite.jpg",
                    HouseholdId = lobby
                }, "Abc&123!");
            }

            if (!context.Users.Any(u => u.Email == "demoHoH@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "demoHoH",
                    UserName = "demoHoH@mailinator.com",
                    Email = "demoHoH@mailinator.com",
                    FirstName = "John",
                    LastName = "Doe",
                    DisplayName = "Johnny",
                    AvatarUrl = "/Avatars/defaultAvatar.jpg",
                    HouseholdId=demoHouse
                }, "Abc&123!");
            }

            if (!context.Users.Any(u => u.Email == "demomember@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Id = "demomember",
                    UserName = "demomember@mailinator.com",
                    Email = "demomember@mailinator.com",
                    FirstName = "Jane",
                    LastName = "Doe",
                    DisplayName = "Jane",
                    AvatarUrl = "/Avatars/defaultAvatar.jpg",
                    HouseholdId = demoHouse
                }, "Abc&123!");
            }

            context.SaveChanges();
            #endregion

            #region Role Assignment

            var userId = userManager.FindByEmail("atbrooks84@gmail.com").Id;
            userManager.AddToRole(userId, "HeadOfHouse");

            userId = userManager.FindByEmail("lauragrafphoto@gmail.com").Id;
            userManager.AddToRole(userId, "Member");

            userId = userManager.FindByEmail("sprite@mailinator.com").Id;
            userManager.AddToRole(userId, "Lobby");

            userId = userManager.FindByEmail("demoHoH@mailinator.com").Id;
            userManager.AddToRole(userId, "DemoHoH");

            userId = userManager.FindByEmail("demomember@mailinator.com").Id;
            userManager.AddToRole(userId, "DemoMember");

            context.SaveChanges();
            #endregion
            

            #region Budget Creation
            
            context.Budgets.AddOrUpdate(
                b => b.Name,
                new Budget {
                    Name = "Household Utilities",
                    HouseholdId = brooksHouse,
                    Created =DateTime.Now,
                    Target =800, Actual=0 }
                

            );

            context.SaveChanges();
            #endregion

            #region Account Type Creation
            context.AccountTypes.AddOrUpdate(
                a=>a.Type,

                new AccountType { Name = "Normal Checking", Type="Checking", Description = "Default Checking Account"},
                new AccountType { Name = "Normal Savings", Type="Savings", Description = "Default Savings Account"}
                
                );
            context.SaveChanges();
            #endregion

            #region Transaction Type Creation

            context.TransactionTypes.AddOrUpdate(
                t=>t.Type,
                new TransactionType { Type= "Deposit", Description = "Added money to account"},
                new TransactionType { Type= "Withdrawal", Description = "Took money out of account"}
                
                );
            context.SaveChanges();
            #endregion

            #region Budget Item Creation

            var budgets = context.Budgets.AsNoTracking();
            var utilitiesBudgetId = budgets.FirstOrDefault(b => b.Name == "Household Utilities").Id;

            context.BudgetItems.AddOrUpdate(
                t =>t.Name,
                new BudgetItem { Name = "Gas", BudgetId = utilitiesBudgetId, Created=DateTime.Now, Ammount = 30},
                new BudgetItem { Name = "Water", BudgetId = utilitiesBudgetId, Created = DateTime.Now, Ammount = 30 },
                new BudgetItem { Name = "Electric", BudgetId = utilitiesBudgetId, Created = DateTime.Now, Ammount = 80 },
                new BudgetItem { Name = "Internet", BudgetId = utilitiesBudgetId, Created = DateTime.Now, Ammount = 150 },
                new BudgetItem { Name = "Groceries", BudgetId = utilitiesBudgetId, Created = DateTime.Now, Ammount = 250 },
                new BudgetItem { Name = "Cell", BudgetId = utilitiesBudgetId, Created = DateTime.Now, Ammount = 200 }


                );
            context.SaveChanges();

            #endregion

            #region Bank Account Creation
            var accountTypes = context.AccountTypes.AsNoTracking();

            context.BankAccounts.AddOrUpdate(
                b=>b.Name,
                new BankAccount
                {
                    Name = "SECU Checking",
                    HouseholdId = brooksHouse,
                    StartingBalance = 5000,
                    CurrentBalance = 5000,
                    AccountTypeId = accountTypes.FirstOrDefault(a=>a.Type == "Checking").Id,
                    Created = DateTime.Now,
                    Description = "This is our main checking account",
                    OwnerId = "eldergod",
                    Street = "1036 S Park St",
                    City= "Asheboro",
                    State= "NC",
                },


                 new BankAccount
                 {
                     Name = "SECU Savings",
                     HouseholdId = brooksHouse,
                     StartingBalance = 5000,
                     CurrentBalance = 5000,
                     AccountTypeId = accountTypes.FirstOrDefault(a => a.Type == "Savings").Id,
                     Created = DateTime.Now,
                     Description = "This is our main savings account",
                     OwnerId = "eldergod",
                     Street = "1036 S Park St",
                     City = "Asheboro",
                     State = "NC",
                 }

                );



            #endregion
            #region Transaction Creation

            var budgetItems = context.BudgetItems.AsNoTracking();
            var gasBudgetItemId = budgetItems.FirstOrDefault(b => b.Name == "Gas").Id;
            var electricBudgetItemId = budgetItems.FirstOrDefault(b => b.Name == "Electric").Id;

            var checkingAccountId = accountTypes.FirstOrDefault(a => a.Name == "Normal Checking").Id;
            var savingsAccountId = accountTypes.FirstOrDefault(a => a.Name == "Normal Savings").Id;

            var transactionTypes = context.TransactionTypes.AsNoTracking();
            var depositTransactionTypeId = transactionTypes.FirstOrDefault(t => t.Type == "Deposit").Id;
            var withdrawalTransactionTypeId = transactionTypes.FirstOrDefault(t => t.Type == "Withdrawal").Id;

            context.Transactions.AddOrUpdate(
                t => t.Memo,

                new Transaction
                {
                    BankAccountId = checkingAccountId,
                    BudgetItemId = gasBudgetItemId,
                    UserId = "eldergod",
                    TypeId = withdrawalTransactionTypeId,
                    Amount = 50.36,
                    Created = DateTime.Now,
                    Memo = "paid monthly gas bill"
                },

                 new Transaction
                 {
                     BankAccountId = checkingAccountId,
                     BudgetItemId = electricBudgetItemId,
                     UserId = "eldergod",
                     TypeId = withdrawalTransactionTypeId,
                     Amount = 75.25,
                     Created = DateTime.Now,
                     Memo = "paid monthly electric bill"
                 },

                  new Transaction
                  {
                      BankAccountId = checkingAccountId,
                      BudgetItemId = null,
                      UserId = "wife",
                      TypeId = depositTransactionTypeId,
                      Amount = 800,
                      Created = DateTime.Now,
                      Memo = "Recieved paycheck"
                  },

                   new Transaction
                   {
                       BankAccountId = savingsAccountId,
                       BudgetItemId = null,
                       UserId = "wife",
                       TypeId = depositTransactionTypeId,
                       Amount = 200,
                       Created = DateTime.Now,
                       Memo = "Recieved paycheck"
                   }

                );
            context.SaveChanges();
            #endregion

        }
    }
}
