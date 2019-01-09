namespace BusinessDomainClasses.Migrations.BusinessClassesMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BusinessDomainClasses.BusinessDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\BusinessClassesMigrations";
        }

        protected override void Seed(BusinessDomainClasses.BusinessDbContext context)
        {
            context.Suppliers.AddOrUpdate(new Supplier[]
            {
                new Supplier("Supplier 1", "Address for Supplier 1"),
                new Supplier("Supplier 2", "Address for Supplier 2"),
                new Supplier("Supplier 3", "Address for Supplier 3")
            });
            context.SaveChanges();

            context.Categories.AddOrUpdate(new Category[]
            {
                new Category("Bikes"),
                new Category("Components"),
                new Category("Clothing"),
                new Category("Accessories")
            });
            context.SaveChanges();

            context.Products.AddOrUpdate(new Product[]
            {
                new Product("Adjustable Race", 1, 2, 1000, 100.0f),
                new Product("Bearing Ball", 2, 2, 1000, 1.0f),
                new Product("BB Ball Bearing", 2, 2, 800, 2.0f),
                new Product("Headset Ball Bearings", 1, 2, 800, 10.0f),
                new Product("Blade", 1, 4, 800, 25.50f),
                new Product("LL Crankarm", 3, 1, 500, 500),
                new Product("ML Crankarm", 3, 1, 500, 200)
                
            });
            context.SaveChanges();
        }
    }
}
