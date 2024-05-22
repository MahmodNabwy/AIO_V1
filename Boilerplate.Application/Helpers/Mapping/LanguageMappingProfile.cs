using Boilerplate.Contracts.DTOs.Getter.Lookups;
using Boilerplate.Contracts.DTOs.Setter.Languages.Language;
using Boilerplate.Contracts.Features.Languages.Commands;
using Boilerplate.Contracts.Features.Languages.DTOs.Getter.Language;
using Boilerplate.Contracts.Features.Languages.DTOs.Getter.LanguageTranslation;
using Boilerplate.Contracts.Features.Languages.DTOs.Setter.LanguageTranslation;
using Boilerplate.Core.Entities.Languages;

namespace Boilerplate.Application.Helpers
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

            CreateMap<Language, LookupGetterDTO>()
                .ForMember(d => d.Translations, o => o.MapFrom(x => x.LanguageTranslations));
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
