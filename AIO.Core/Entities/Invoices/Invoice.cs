using AIO.Contracts.Enums;
using AIO.Core.Entities.InvoicePaymentOrders;
using AIO.Core.Entities.Owners;
using AIO.Core.Entities.Projects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.Entities.Invoices
{
    [Table("invoices")]
    public class Invoice : BaseEntityUpdate
    {

        [Required(ErrorMessage = "Invoice Number is required")]
        [Column("invoice_number")]
        public int InvoiceNumber { get; set; }

        [Required(ErrorMessage = "Is Paid is required")]
        [Column("is_paid")]
        public bool IsPaid { get; set; }

        [Required(ErrorMessage = "Total Price is required")]
        [Column("total_price")]
        public decimal TotalPrice { get; set; }


        [Required(ErrorMessage = "Owner Id is required")]
        [Column("owner_id")]
        public int OwnerId { get; set; }


        [Required(ErrorMessage = "Project Id is required")]
        [Column("project_id")]
        public int ProjectId { get; set; }


        [Required(ErrorMessage = "Collection Type Id is required")]
        [Column("collectin_type_id")]
        public CollectingType CollectionType { get; set; }


        [ForeignKey(nameof(OwnerId))]
        public virtual Owner Owner { get; set; }


        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; }


        public virtual ICollection<InvoicePaymentOrder> InvoicePaymentOrders { get; set; }

    }
}
