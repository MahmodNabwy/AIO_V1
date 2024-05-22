using AIO.Contracts.Bases;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace AIO.Contracts.DTOs.Setter.Elements.ElementTranslation
{
    public class ElementTranslationSetterDTO : BaseSetterTranslationDTO
    {
        [Required(ErrorMessage = "Value is required")]
        public string Value { get; set; }
    }
}
