using AIO.Contracts.Enums;
using AIO.Core.Entities.Owners;
using AIO.Core.Entities.Projects;
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
    [Table("suppliers_projects_payment_methods")]
    public class SupplierProjectPaymentMethod : BaseEntityUpdate
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

        [Required(ErrorMessage = "Supplier Id is required")]
        [Column("supplier_id")]
        public int SupplierId { get; set; }


        [Required(ErrorMessage = "Project Id is required")]
        [Column("project_id")]
        public int ProjectId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public virtual Supplier Supplier { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; }



    }
}
