using BusinessDomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supplier = BusinessDomainClasses.Supplier;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            get_supplier_parts("Supplier 1");
        }

        static void get_supplier_parts(string supplierName)
        {
            BusinessDbContext bussinesDbContext = new BusinessDbContext();

            List<Supplier> suppliers = bussinesDbContext.Suppliers.ToList();
            Console.WriteLine(suppliers.Count);
            foreach (var supplier in suppliers)
            {
                Console.WriteLine(supplier.Name);
            }/*
            int supplierID = dbContext.Suppliers.Where(s => s.Name == supplierName).FirstOrDefault().SupplierID;
            List<Product> supplierProducts = dbContext.Products.Where(p => p.SupplierID == supplierID).ToList();
            foreach (var supplierProduct in supplierProducts)
            {
                Console.WriteLine(supplierProduct.Description);
            }
            */
            Console.ReadKey();
        }
    }
}
