using AIO.Core.Entities.Invoices;
using AIO.Core.Entities.Projects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.Entities.InvoicePaymentOrders
{

    [Table("invoice_payment_order")]
    public class InvoicePaymentOrder : BaseEntityUpdate
    {

        [Required(ErrorMessage = "Payment Value is required")]
        [Column("payment_value")]
        public decimal PaymentValue { get; set; }


        [Required(ErrorMessage = "Payment Date is required")]
        [Column("payment_date")]
        public DateTime PaymentDate { get; set; }

        [Column("discount_value")]
        public decimal? DiscountValue { get; set; }

        [Required(ErrorMessage = "Project Id is required")]
        [Column("project_id")]
        public int ProjectId { get; set; }


        [Required(ErrorMessage = "Invoice Id is required")]
        [Column("invoice_id")]
        public int InvoiceId { get; set; }


        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; }


        [ForeignKey(nameof(InvoiceId))]
        public virtual Invoice Invoice { get; set; }


    }
}
