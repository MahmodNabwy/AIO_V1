using AIO.Contracts.DTOs.Getter.Lookups;
using AIO.Contracts.DTOs.Setter.Languages.Language;
using AIO.Contracts.Features.Languages.Commands;
using AIO.Contracts.Features.Languages.DTOs.Getter.Language;
using AIO.Contracts.Features.Languages.DTOs.Getter.LanguageTranslation;
using AIO.Contracts.Features.Languages.DTOs.Setter.LanguageTranslation;
using AIO.Core.Entities.Languages;

namespace AIO.Application.Helpers
{
    public partial class MappingProfile
    {
        private void LanguageMappingProfile()
        {
            #region Language
            CreateMap<CreateLanguageCommand, Language>();

            CreateMap<UpdateLanguageCommand, Language>();

            CreateMap<LanguageSetterDTO, Language>().ReverseMap();

            CreateMap<LanguageUpdateSetterDTO, Language>().ReverseMap();

            CreateMap<Language, LanguageGetterDTO>();

            CreateMap<Language, LanguageDataGetterDTO>();

            //CreateMap<Language, LookupGetterDTO>()
            //    .ForMember(d => d.Translations, o => o.MapFrom(x => x.LanguageTranslations));
            #endregion

            #region Language Translation

            CreateMap<LanguageTranslationSetterDTO, LanguageTranslation>().ReverseMap();

            CreateMap<LanguageTranslationUpdateSetterDTO, LanguageTranslation>().ReverseMap();

            CreateMap<LanguageTranslation, LanguageTranslationGetterDTO>();

            CreateMap<LanguageTranslation, LanguageTranslationDataGetterDTO>();

            CreateMap<LanguageTranslation, LookupTranslationGetterDTO>();

            #endregion
        }
    }
}
