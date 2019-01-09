using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessDomainClasses
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }
        [Display(Name = "Category")]
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Category(string description)
        {
            this.Description = description;
        }

        public Category()
        {

        }
    }
}
