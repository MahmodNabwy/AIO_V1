using Boilerplate.Contracts.Bases;
using Boilerplate.Contracts.DTOs.Getter.Elements.ElementTranslation;
#nullable disable

namespace Boilerplate.Contracts.DTOs.Getter.Elements.Element
{
    public class ElementDataGetterDTO : BaseGetterDTO
    {
        public string key { get; set; }
        public string Value { get; set; }
        public List<ElementTranslationDataGetterDTO> ElementTranslations { get; set; }

    }
}
