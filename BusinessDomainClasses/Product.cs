using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessDomainClasses
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }
        [Display(Name = "Product Name")]
        public string Description { get; set; }
        [Display(Name = "Quantity in Stock")]
        public int QuantityInStock { get; set; }
        [Display(Name = "Unit Price")]
        public float UnitPrice { get; set; }
        [ForeignKey("ProductSupplier")]
        public int SupplierID { get; set; }
        [ForeignKey("ProductCategory")]
        public int CategoryID { get; set; }
        public virtual Supplier ProductSupplier { get; set; }
        public virtual Category ProductCategory { get; set; }

        public Product(string Description, int SupplierID, int CategoryID, int Quantity, float UnitPrice)
        {
            this.Description = Description;
            this.SupplierID = SupplierID;
            this.CategoryID = CategoryID;
            this.QuantityInStock = Quantity;
            this.UnitPrice = UnitPrice;
        }

        public Product()
        {
        }
    }
}
