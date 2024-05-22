using AIO.Contracts.Bases;
using AIO.Contracts.DTOs.Getter.Elements.ElementTranslation;
#nullable disable

namespace AIO.Contracts.DTOs.Getter.Elements.Element
{
    public class ElementDataGetterDTO : BaseGetterDTO
    {
        public string key { get; set; }
        public string Value { get; set; }
        public List<ElementTranslationDataGetterDTO> ElementTranslations { get; set; }

    }
}
