using AIO.Shared.Resources;
using Microsoft.Extensions.Localization;

namespace AIO.Shared.Interfaces
{
    public interface ICulture
    {
        public IStringLocalizer<SharedResource> SharedLocalizer { get;}
        public IStringLocalizer<PagesResource> PagesLocalizer { get;}
    }
}
