using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.Entities.InvoiceItems
{
    [Table("invoice_items")]
    public class InvoiceItems : BaseEntityUpdate
    { 
            
        [Required(ErrorMessage = "Quantity is required")]
        [Column("quantity")]
        public int Quantity { get; set; }


        [Required(ErrorMessage = "Total Price is required")]
        [Column("total_price")]
        public decimal TotalPrice { get; set; }


        [Column("description")]
        public string description { get; set; }



    }
}
