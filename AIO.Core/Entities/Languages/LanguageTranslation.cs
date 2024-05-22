using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace AIO.Core.Entities.Languages
{
    [Table("language_translations")]
    public class LanguageTranslation : BaseEntityTranslation
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Max length is 50 characters")]
        [Column("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Language Id is required")]
        [Column("language_id")]
        public int LanguageId { get; set; }
        [ForeignKey(nameof(LanguageId))]
        public virtual Language Language { get; set; }
    }
}
