using AIO.Core.Entities.StatementCategories;
using AIO.Core.Entities.SupplierCategories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.Entities.Categories
{
    [Table("category")]
    public class Category : BaseEntityUpdate
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Max length is 50 characters")]
        [Column("name")]
        public string Name { get; set; }


        public virtual ICollection<StatementCategory> StatementCategories { get; set; }
        public virtual ICollection<SupplierCategory> SupplierCategories { get; set; }


    }
}
