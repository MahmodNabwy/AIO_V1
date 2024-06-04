using AIO.Contracts.Enums;
using AIO.Core.Entities.Owners;
using AIO.Core.Entities.Projects;
using AIO.Core.Entities.Taxes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.Entities.ProjectInsurances
{

    [Table("projects_insurances")]

    public class ProjectInsurance : BaseEntityUpdate
    {
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

        [Required(ErrorMessage = "Is Returned Is Required")]
        [Column("is_returned")]
        public bool IsReturned { get; set; }

        [Required(ErrorMessage = "Insurance Type is required")]
        [Column("type_id ")]
        public Insurance_types TypeId { get; set; }

        [Required(ErrorMessage = "currency is required")]
        [Column("currency")]
        [NotMapped]
        public currency_type currency { get { return Project.currency; } }

        [Column("insurance_letter_value")]
        public decimal? InsuranceLetterValue { get; set; }


        [Required(ErrorMessage = "Insurance Letter Status is required")]
        [Column("status_id ")]
        public Inusrance_letter_status StatusId { get; set; }


        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; }
    }
}
