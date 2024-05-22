using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace AIO.Core.Entities.Elements
{
    [Table("elements")]
    public class Element : BaseEntityUpdate
    {
        [Required(ErrorMessage = "key is required")]
        [Column("key")]
        public string key { get; set; }
        [Column("value")]
        public string Value { get; set; }
        public virtual ICollection<ElementTranslation> ElementTranslations { get; set; }
    }
}
