using AIO.Contracts.Bases;
using AIO.Contracts.Features.Languages.DTOs.Getter.LanguageTranslation;
#nullable disable

namespace AIO.Contracts.Features.Languages.DTOs.Getter.Language
{
    public class LanguageGetterDTO : BaseGetterUpdateDTO
    {
        public string Name { get; set; }
        public string Locale { get; set; }
        public string Flag { get; set; }
        public bool IsDefault { get; set; }
        public List<LanguageTranslationGetterDTO> LanguageTranslations { get; set; }


    }
}