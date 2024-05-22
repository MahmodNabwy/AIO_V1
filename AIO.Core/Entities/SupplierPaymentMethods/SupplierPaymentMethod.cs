using AIO.Core.Entities.Owners;
using AIO.Core.Entities.PaymentMethods;
using AIO.Core.Entities.Suppliers;
using AIO.Core.Entities.Taxes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.Entities.SupplierPaymentMethods
{
    [Table("supplier_payment_method")]
    public class SupplierPaymentMethod : BaseEntityUpdate
    {

        [Required(ErrorMessage = "Supplier Id is required")]
        [Column("supplier_id")]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Payment Method Id is required")]
        [Column("payment_method_id")]
        public int PaymentMethodId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public virtual Supplier Supplier { get; set; }

        [ForeignKey(nameof(PaymentMethodId))]
        public virtual PaymentMethod PaymentMethod { get; set; }
    }
}
