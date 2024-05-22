using Boilerplate.Contracts.DTOs.Getter.FileLibrary;
using Boilerplate.Core.Entities.FilesLibrary;
using Boilerplate.Shared.Helpers;
using Microsoft.Extensions.Options;

namespace Boilerplate.Application.Helpers
{
    public partial class MappingProfile
    {
        private void FileLibraryMappingProfile()
        {
            #region FilesLibrary

            CreateMap<FilesLibrary, FileLibraryGetterDTO>()
                .ForMember(dest => dest.Thumbnail, o => o.MapFrom(src => src.ThumbnailUrl));

            #endregion
        }
    }
}