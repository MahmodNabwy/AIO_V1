using AIO.Contracts.Enums;
using AIO.Core.Entities.ProjectPaymentMethods;
using AIO.Core.Entities.SupplierPaymentMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.Entities.PaymentMethods
{

    [Table("payment_method")]
    public class PaymentMethod : BaseEntityUpdate
    {
        [Required(ErrorMessage = "Percentage is required")]
        [Column("percentage")]
        public int Percentage { get; set; }


        [Required(ErrorMessage = "Amount is required")]
        [Column("amount")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Amount Concurrency  is required")]
        [Column("amount_concurrency ")]
        public Concurrency_type AmountConcurrency { get; set; }


        [Required(ErrorMessage = "Payment Method Type is required")]
        [Column("type_id ")]
        public PaymentMethodTypes TypeId { get; set; }

        public virtual ICollection<ProjectPaymentMethod> ProjectPaymentMethods { get; set; }
        public virtual ICollection<SupplierPaymentMethod> SupplierPaymentMethods { get; set; }


    }
}
