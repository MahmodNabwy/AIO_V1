using AIO.Core.Entities.Attachments;
using AIO.Core.Entities.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.Entities.SupplierAttachmets
{
    [Table("suppliers_attachments")]
    public class SupplierAttachment : BaseEntityUpdate
    {
        [Required(ErrorMessage = "Supplier Id is required")]
        [Column("supplier_id")]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Attachment Id is required")]
        [Column("attachment_id")]
        public int AttachmentId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public virtual Supplier Supplier { get; set; }

        [ForeignKey(nameof(AttachmentId))]
        public virtual Attachment Attachment { get; set; }
    }
}
