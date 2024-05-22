using AIO.Contracts.Enums;
using AIO.Core.Entities.ProjectInsurances;
using AIO.Core.Entities.SupplierInsurances;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.Entities.Insurance_conditions
{
    [Table("insurance_condition")]
    public class Insurance_Condition : BaseEntityUpdate
    {

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

        [Required(ErrorMessage = "Insurance Letter Status is required")]
        [Column("status_id ")]
        public Inusrance_letter_status StatusId { get; set; }

        public virtual ICollection<ProjectInsurance> ProjectInsurances { get; set; }

        public virtual ICollection<SupplierProjectInsurance> SupplierProjectInsurances { get; set; }


    }
}
