using AIO.Core.Entities.ProjectSuppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.Entities.ProjectSupplierAttachments
{
    [Table("projects_suppliers_attachments")]
    public class ProjectSupplierAttachment : BaseEntityAttachment
    {
        [Required(ErrorMessage = "Project Supplier Id is required")]
        [Column("project_supplier_id")]
        public int ProjectSupplierId { get; set; }

        [ForeignKey(nameof(ProjectSupplierId))]
        public virtual ProjectSupplier ProjectSupplier { get; set; }
    }
}
