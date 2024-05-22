using AIO.Core.Entities.Categories;
using AIO.Core.Entities.Insurance_conditions;
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


        [Required(ErrorMessage = "Insurance Condition Id is required")]
        [Column("insurance_condition_id")]
        public int InsuranceConditionId { get; set; }



        [ForeignKey(nameof(SupplierId))]
        public virtual Supplier Supplier { get; set; }


        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; }


        [ForeignKey(nameof(InsuranceConditionId))]
        public virtual Insurance_Condition InsuranceCondition { get; set; }
    }
}
