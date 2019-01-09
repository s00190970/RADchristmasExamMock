using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessDomainClasses
{
    public class BusinessDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public BusinessDbContext() : base("SupplierConnection")
        {

        }

        public BusinessDbContext Create()
        {
            return new BusinessDbContext();
        }
    }
}
