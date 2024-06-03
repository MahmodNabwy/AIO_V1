using AIO.Contracts.Enums;
using AIO.Core.Entities.Categories;
using AIO.Core.Entities.Projects;
using AIO.Core.Entities.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.Entities.SupplierInsurances
{
    [Table("suppliers_projects_insurances")]

    public class SupplierProjectInsurance : BaseEntityUpdate
    {


        [Required(ErrorMessage = "Supplier Id is required")]
        [Column("supplier_id")]
        public int SupplierId { get; set; }


        [Required(ErrorMessage = "Project Id is required")]
        [Column("project_id")]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Percentage is required")]
        [Column("percentage")]
        public int Percentage { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Column("amount")]
        public decimal Amount { get; set; }

        [Column("date")]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "Period is required")]
        [Column("period")]
        public int Period { get; set; }

        [Required(ErrorMessage = "Insurance Type is required")]
        [Column("type_id ")]
        public Insurance_types TypeId { get; set; }

        [Required(ErrorMessage = "Amount Concurrency Type is required")]
        [Column("amount_concurrency_type ")]
        public Concurrency_type Amount_Concurrency_Type { get; set; }
        
        [Column("insurance_letter_value")]
        public decimal? InsuranceLetterValue { get; set; }


        [Column("insurance_letter_concurrency_type ")]
        public Concurrency_type? Insurance_letter_Concurrency_Type { get; set; }

        [Required(ErrorMessage = "Insurance Letter Status is required")]
        [Column("status_id ")]
        public Inusrance_letter_status StatusId { get; set; }


        [ForeignKey(nameof(SupplierId))]
        public virtual Supplier Supplier { get; set; }


        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; }


    }
}
