using Boilerplate.Contracts.Bases;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Boilerplate.Contracts.DTOs.Setter.Elements.ElementTranslation
{
    public class ElementTranslationUpdateSetterDTO : BaseUpdateTranslationDTO
    {
        [Required(ErrorMessage = "Value is required")]
        public string Value { get; set; }
    }
}
