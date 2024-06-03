using AIO.Core.Entities.Projects;
using AIO.Core.Entities.Taxes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.Entities.ProjectsTaxes
{
    [Table("projects_taxes")]
    public class ProjectTaxe : BaseEntityUpdate
    {
        [Required(ErrorMessage = "Project Id is required")]
        [Column("project_id")]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Tax Id is required")]
        [Column("tax_id")]
        public int TaxId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; }

        [ForeignKey(nameof(TaxId))]
        public virtual Tax Taxe { get; set; }
    }
}
