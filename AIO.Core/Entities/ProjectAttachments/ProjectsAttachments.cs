using AIO.Core.Entities.Attachments;
using AIO.Core.Entities.Owners;
using AIO.Core.Entities.Projects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.Entities.ProjectAttachments
{
    [Table("projects_attachments")]
    public class ProjectsAttachments : BaseEntityUpdate
    {

        [Required(ErrorMessage = "Project Id is required")]
        [Column("project_id")]
        public int ProjectId { get; set; }


        [Required(ErrorMessage = "Attachment Id is required")]
        [Column("attachment_id")]
        public int AttachmentId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; }


        [ForeignKey(nameof(AttachmentId))]
        public virtual Attachment Attachment { get; set; }
    }
}
