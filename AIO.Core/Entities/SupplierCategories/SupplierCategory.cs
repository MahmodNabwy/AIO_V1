using AIO.Core.Entities.Categories;
using AIO.Core.Entities.Owners;
using AIO.Core.Entities.Suppliers;
using AIO.Core.Entities.Taxes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.Entities.SupplierCategories
{
    [Table("suppliers_categories")]
    public class SupplierCategory : BaseEntityUpdate
    {
        [Required(ErrorMessage = "Total Price is required")]
        [Column("total_price")]
        public decimal TotalPrice { get; set; }


        [Required(ErrorMessage = "Supplier Id is required")]
        [Column("supplier_id")]
        public int SupplierId { get; set; }


        [Required(ErrorMessage = "Category Id is required")]
        [Column("category_id")]
        public int CategoryId { get; set; }



        [ForeignKey(nameof(SupplierId))]
        public virtual Supplier Supplier { get; set; }


        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }
    }
}
