using AIO.Contracts.DTOs.Getter.FileLibrary;
using AIO.Core.Entities.FilesLibrary;
using AIO.Shared.Helpers;
using Microsoft.Extensions.Options;

namespace AIO.Application.Helpers
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