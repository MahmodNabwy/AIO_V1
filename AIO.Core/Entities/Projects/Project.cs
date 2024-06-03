using AIO.Contracts.Enums;
using AIO.Core.Entities.Departments;
using AIO.Core.Entities.InvoicePaymentOrders;
using AIO.Core.Entities.Invoices;
using AIO.Core.Entities.OwnerAttachments;
using AIO.Core.Entities.Owners;
using AIO.Core.Entities.ProjectAttachments;
using AIO.Core.Entities.ProjectInsurances;
using AIO.Core.Entities.ProjectPaymentMethods;
using AIO.Core.Entities.ProjectsTaxes;
using AIO.Core.Entities.ProjectSuppliers;
using AIO.Core.Entities.Statements;
using AIO.Core.Entities.SupplierCategories;
using AIO.Core.Entities.SupplierInsurances;
using AIO.Core.Entities.SupplierItems;
using AIO.Core.Entities.SupplierPaymentMethods;
using AIO.Core.Entities.Taxes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.Entities.Projects
{
    [Table("projects")]
    public class Project : BaseEntityUpdate
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        [Column("name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Contract Number is required")]
        [StringLength(100)]
        [Column("contract_number")]
        public string ContractNumber { get; set; }

        [Required(ErrorMessage = "PO Number is required")]
        [StringLength(100)]
        [Column("po_number")]
        public string PoNumber { get; set; }

        [Required(ErrorMessage = "Assigned Number is required")]
        [StringLength(100)]
        [Column("Assigned_number")]
        public string AssignedNumber { get; set; }


        [Required(ErrorMessage = "Assigned To Date is required")]
        [Column("assigned_to_date")]
        public DateTime AssignedToDate { get; set; }


        [Required(ErrorMessage = "Primare Reciept Date is required")]
        [Column("primary_reciept_date")]
        public DateTime PrimaryRecieptDate { get; set; }


        [Required(ErrorMessage = "Final Reciept Date is required")]
        [Column("final_reciept_date")]
        public DateTime FinalRecieptDate { get; set; }

        [Required(ErrorMessage = "Total Price is required")]
        [Column("total_price")]
        public decimal TotalPrice { get; set; }


        [Required(ErrorMessage = "currency is required")]
        [Column("currency")]
        public currency_type currency { get; set; }

        [Required(ErrorMessage = "Limit Of Liability is required")]
        [Column("limit_of_liability")]
        public decimal LimitOfLiability { get; set; }


        [Column("project_profitability_ratio")]
        public int? ProjectProfitabilityRatio { get; set; }

        [Required(ErrorMessage = "Implementation Period is required")]
        [Column("implementation_period")]
        public int ImplementationPeriod { get; set; }


        [Required(ErrorMessage = "Insurance Period is required")]
        [Column("insurance_period")]
        public int InsurancePeriod { get; set; }

        [Required(ErrorMessage = "Payment Condition is required")]
        [Column("payment_condition")]
        public string PaymentCondition { get; set; }


        [Required(ErrorMessage = "Is New is required")]
        [Column("is_new")]
        public bool IsNew { get; set; }

        [Required(ErrorMessage = "Include Taxes is required")]
        [Column("include_taxes")]
        public bool IncludeTaxes { get; set; }


        [Column("parent_id")]
        public int? ParentId { get; set; }


        [Column("is_confirmed")]
        public bool IsConfirmed { get; set; } = false;

        [Required(ErrorMessage = "Project Type Id is required")]
        [Column("project_type_id ")]
        public ProjectType ProjectTypeId { get; set; }


        [Column("has_discount")]
        public bool? HasDiscount { get; set; } = false;

        [Column("total_price_after_discount")]
        public decimal? TotalPriceAfterDiscount { get; set; }

        [Required(ErrorMessage = "Owner Id is required")]
        [Column("owner_id")]
        public int OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public virtual Owner Owner { get; set; }

        [ForeignKey(nameof(ParentId))]
        public virtual Project ParentProject { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<InvoicePaymentOrder> InvoicePaymentOrders { get; set; }
        public virtual ICollection<ProjectInsurance> ProjectInsurances { get; set; }
        public virtual ICollection<ProjectPaymentMethod> ProjectPaymentMethods { get; set; }
        public virtual ICollection<Statement> Statements { get; set; }
        public virtual ICollection<ProjectSupplier> ProjectSuppliers { get; set; }
        public virtual ICollection<SupplierProjectInsurance> SupplierProjectInsurances { get; set; }
        public virtual ICollection<SupplierProjectItem> SupplierProjectItems { get; set; }
        public virtual ICollection<ProjectsAttachments> ProjectAttachments { get; set; }
        public virtual ICollection<SupplierProjectPaymentMethod> ProjectSupplyPaymentMethods { get; set; }
        public virtual ICollection<ProjectTaxe> ProjectTaxes { get; set; }

    }
}
