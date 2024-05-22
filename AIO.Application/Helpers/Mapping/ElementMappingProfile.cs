using AIO.Contracts.DTOs.Getter.Elements.Element;
using AIO.Contracts.DTOs.Getter.Elements.ElementTranslation;
using AIO.Contracts.DTOs.Setter.Elements.Element;
using AIO.Contracts.DTOs.Setter.Elements.ElementTranslation;
using AIO.Core.Entities.Elements;

namespace AIO.Application.Helpers
{
    public partial class MappingProfile
    {
        private void ElementMappingProfile()
        {
            #region Element

            CreateMap<ElementSetterDTO, Element>();

            CreateMap<ElementUpdateSetterDTO, Element>();

            CreateMap<Element, ElementGetterDTO>();

            CreateMap<Element, ElementDataGetterDTO>();

            #endregion

            #region Element Translation

            CreateMap<ElementTranslationSetterDTO, ElementTranslation>();

            CreateMap<ElementTranslationUpdateSetterDTO, ElementTranslation>();

            CreateMap<ElementTranslation, ElementTranslationGetterDTO>();

            CreateMap<ElementTranslation, ElementTranslationDataGetterDTO>();

            #endregion
        }
    }
}
