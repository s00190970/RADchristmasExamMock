using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessDomainClasses
{
    [Table("Supplier")]
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierID { get; set; }
        [Display(Name = "Supplier Name")]
        public string Name { get; set; }
        [Display(Name = "Supplier Address")]
        public string Address { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Supplier(string name, string address)
        {
            this.Name = name;
            this.Address = address;
        }

        public Supplier()
        {
        }
    }
}
