using AIO.Core.Entities.Categories;
using AIO.Core.Entities.Items;
using AIO.Core.Entities.Projects;
using AIO.Core.Entities.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.Entities.SupplierItems
{
    [Table("suppliers_project_items")]
    public class SupplierProjectItem : BaseEntityUpdate
    {
        
        [Required(ErrorMessage = "Supplier Id is required")]
        [Column("supplier_id")]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Project Id is required")]
        [Column("project_id")]
        public int ProjectId { get; set; }


        [Required(ErrorMessage = "Item Id is required")]
        [Column("item_id")]
        public int ItemId { get; set; }


        [Required(ErrorMessage = "Amount is required")]
        [Column("amount")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Unit Price is required")]
        [Column("unit_price")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Total Price is required")]
        [Column("total_price")]
        public decimal TotalPrice { get; set; }


        [ForeignKey(nameof(SupplierId))]
        public virtual Supplier Supplier { get; set; }


        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; }


        [ForeignKey(nameof(ItemId))]
        public virtual Item Item { get; set; }


    }
}
