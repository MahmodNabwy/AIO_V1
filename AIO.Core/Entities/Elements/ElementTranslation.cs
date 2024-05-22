using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace AIO.Core.Entities.Elements
{
    [Table("element_translations")]
    public class ElementTranslation : BaseEntityTranslation
    {
        [Required(ErrorMessage = "Value is required")]
        [Column("value")]
        public string Value { get; set; }
        [Required(ErrorMessage = "Element Id is required")]
        [Column("element_id")]
        public long ElementId { get; set; }
        [ForeignKey(nameof(ElementId))]
        public virtual Element Element { get; set; }
    }
}
