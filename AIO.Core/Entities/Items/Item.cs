using AIO.Core.Entities.SupplierItems;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.Entities.Items
{
    [Table("items")]
    public class Item : BaseEntityUpdate
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Max length is 50 characters")]
        [Column("name")]
        public string Name { get; set; }

       
        [StringLength(500, ErrorMessage = "Max length is 500 characters")]
        [Column("description")]
        public string Description { get; set; }


        [Column("price")]
        public decimal Price { get; set; }


        public virtual ICollection<SupplierProjectItem> SupplierProjectItems { get; set; }

    }
}
