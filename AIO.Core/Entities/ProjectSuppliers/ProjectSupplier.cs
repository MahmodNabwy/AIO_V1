using AIO.Contracts.Enums;
using AIO.Core.Entities.ProjectAttachments;
using AIO.Core.Entities.Projects;
using AIO.Core.Entities.ProjectSupplierAttachments;
using AIO.Core.Entities.Suppliers;
using AIO.Core.Entities.Taxes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.Entities.ProjectSuppliers
{
    [Table("projects_suppliers")]
    public class ProjectSupplier : BaseEntityUpdate
    {
        [Required(ErrorMessage = "Contract Number is required")]
        [StringLength(100)]
        [Column("contract_number")]
        public string ContractNumber { get; set; }


        [Required(ErrorMessage = "Primare Reciept Date is required")]
        [Column("primary_reciept_date")]
        public DateTime PrimaryRecieptDate { get; set; }


        [Required(ErrorMessage = "Final Reciept Date is required")]
        [Column("final_reciept_date")]
        public DateTime FinalRecieptDate { get; set; }


        [Required(ErrorMessage = "Total Price is required")]
        [Column("total_price")]
        public decimal TotalPrice { get; set; }


        [Required(ErrorMessage = "Total Price Concurrency is required")]
        [Column("total_price_concurrency")]
        public Concurrency_type TotalPriceConcurrency { get; set; }


        [Required(ErrorMessage = "Implementation Period is required")]
        [Column("implementation_period")]
        public int ImplementationPeriod { get; set; }


        [Required(ErrorMessage = "Insurance Period is required")]
        [Column("insurance_period")]
        public int InsurancePeriod { get; set; }


        [Required(ErrorMessage = "Payment Condition is required")]
        [Column("payment_condition")]
        public string PaymentCondition { get; set; }


        [Required(ErrorMessage = "Tax Id is required")]
        [Column("tax_id")]
        public int TaxId { get; set; }


        [ForeignKey(nameof(TaxId))]
        public virtual Taxe Taxe { get; set; }


        [Required(ErrorMessage = "Project Id is required")]
        [Column("project_id")]
        public int ProjectId { get; set; }


        [Required(ErrorMessage = "Supplier Id is required")]
        [Column("supplier_id")]
        public int SupplierId { get; set; }


        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; }


        [ForeignKey(nameof(SupplierId))]
        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<ProjectSupplierAttachment> ProjectSupplierAttachment { get; set; }



    }
}
