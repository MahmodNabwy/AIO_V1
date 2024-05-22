using Boilerplate.Contracts.Bases;
using Boilerplate.Contracts.DTOs.Setter.Elements.ElementTranslation;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Boilerplate.Contracts.DTOs.Setter.Elements.Element
{
    public class ElementUpdateSetterDTO : BaseSetterDTO
    {
        [Required(ErrorMessage = "Key is required")]
        public string key { get; set; }
        public string Value { get; set; }
        [Required(ErrorMessage = "Translation is required")]
        public virtual ICollection<ElementTranslationUpdateSetterDTO> ElementTranslations { get; set; }
    }
}
