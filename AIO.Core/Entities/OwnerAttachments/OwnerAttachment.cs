using AIO.Core.Entities.Attachments;
using AIO.Core.Entities.Owners;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.Entities.OwnerAttachments
{
    [Table("owners_attachments")]
    public class OwnerAttachment : BaseEntityUpdate
    {

        [Required(ErrorMessage = "Owner Id is required")]
        [Column("owner_id")]
        public int OwnerId { get; set; }

        [Required(ErrorMessage = "Attachment Id is required")]
        [Column("attachment_id")]
        public int AttachmentId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public virtual Owner Owner { get; set; }

        [ForeignKey(nameof(AttachmentId))]
        public virtual Attachment Attachment { get; set; }
    }
}
