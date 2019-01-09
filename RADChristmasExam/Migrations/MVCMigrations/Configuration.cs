using System.Collections.Generic;

namespace RADChristmasExam.Migrations.MVCMigrations
{
    using BusinessDomainClasses;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using RADChristmasExam.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RADChristmasExam.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\MVCMigrations";
        }

        protected override void Seed(RADChristmasExam.Models.ApplicationDbContext context)
        {
            var manager =
                new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(context));

            var roleManager =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));

            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "PurchasesManager" }
            );
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "DataClerk" }
            );

            context.SaveChanges();

            PasswordHasher ps = new PasswordHasher();
            BusinessDbContext bussinesDbContext = new BusinessDbContext();

            List<Supplier> suppliers = bussinesDbContext.Suppliers.ToList();

            foreach (var supplier in suppliers)
            {
                context.Users.AddOrUpdate(u => u.UserName,
                    new ApplicationUser
                    {   
                        UserName = "purchases.manager@"+supplier.Name.ToLower().Replace(" ", string.Empty)+".ie", //purchases.manager@supplier1.ie
                        Email = "purchases.manager@" + supplier.Name.ToLower().Replace(" ", string.Empty) + ".ie",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        PasswordHash = ps.HashPassword(supplier.Name), //Supplier1
                    });
                context.SaveChanges();

                ApplicationUser purchasesManager = manager
                    .FindByEmail("purchases.manager@" + supplier.Name.ToLower().Replace(" ", string.Empty) + ".ie");
                if (purchasesManager != null)
                {
                    manager.AddToRoles(purchasesManager.Id, new string[] { "PurchasesManager" });
                }

                context.Users.AddOrUpdate(u => u.UserName,
                    new ApplicationUser
                    {
                        UserName = "data.clerk@" + supplier.Name.ToLower().Replace(" ", string.Empty) + ".ie",//data.clerk@supplier1.ie
                        Email = "data.clerk@" + supplier.Name.ToLower().Replace(" ", string.Empty) + ".ie",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        PasswordHash = ps.HashPassword(supplier.Name),
                    });
                context.SaveChanges();

                ApplicationUser dataClerk = manager
                    .FindByEmail("data.clerk@" + supplier.Name.ToLower().Replace(" ", string.Empty) + ".ie");
                if (dataClerk != null)
                {
                    manager.AddToRoles(dataClerk.Id, new string[] { "DataClerk" });
                }

                context.SaveChanges();
            }
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    
                    UserName = "purchases.manager@bob.com",
                    Email = "purchases.manager@bob.com",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = ps.HashPassword("TheBoss$1"),
                });
            context.SaveChanges();
            ApplicationUser purchasesManagerBertie = manager
                .FindByEmail("purchases.manager@bob.com");
            if (purchasesManagerBertie != null)
            {
                manager.AddToRoles(purchasesManagerBertie.Id, new string[] { "PurchasesManager" });
            }

        }
    }
}
