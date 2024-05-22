using Boilerplate.Contracts.Bases;
using Boilerplate.Contracts.DTOs.Getter.Elements.ElementTranslation;
#nullable disable

namespace Boilerplate.Contracts.DTOs.Getter.Elements.Element
{
    public class ElementGetterDTO : BaseGetterUpdateDTO
    {
        public string key { get; set; }
        public string Value { get; set; }
        public List<ElementTranslationGetterDTO> ElementTranslations { get; set; }

    }
}
