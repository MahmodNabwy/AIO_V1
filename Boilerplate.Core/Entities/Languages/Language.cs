using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Boilerplate.Core.Entities.Languages
{
    [Table("languages")]
    public class Language : BaseEntityUpdate
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Max length is 50 characters")]
        [Column("name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Locale is required")]
        [StringLength(6, ErrorMessage = "Max length is 6 characters")]
        [Column("locale")]
        public string Locale { get; set; }
        [Column("flag")]
        public string Flag { get; set; }
        [Column("direction")]
        public string Direction { get; set; }
        [Column("is_default")]
        public bool IsDefault { get; set; } = false;
        [Column("is_system")]
        public bool IsSystem { get; set; } = false;
        public virtual ICollection<LanguageTranslation> LanguageTranslations { get; set; }

    }
}
