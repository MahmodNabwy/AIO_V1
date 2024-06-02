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

namespace AIO.Core.Entities.ProjectsSuppliersTaxes
{
    [Table("projects_suppliers_taxes")]
    public class ProjectSupplierTaxe : BaseEntityUpdate
    {
        [Required(ErrorMessage = "Project Id is required")]
        [Column("project_id")]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Taxe Id is required")]
        [Column("taxe_id")]
        public int TaxeId { get; set; }


        [Required(ErrorMessage = "Supplier Id is required")]
        [Column("supplier_id")]
        public int SupplierId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; }

        [ForeignKey(nameof(TaxeId))]
        public virtual Taxe Taxe { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public virtual Supplier Supplier { get; set; }
    }
}
