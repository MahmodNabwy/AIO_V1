using Boilerplate.Contracts.Interfaces.Custom;

namespace Boilerplate.Contracts.IServices.Services.Lookups
{
    public interface ILookupService
    {

        Task<IHolderOfDTO> GetDepartmnetsAsync();
        Task<IHolderOfDTO> GetUserAsync();
        Task<IHolderOfDTO> GetRoleAsync();
        Task<IHolderOfDTO> GetLanguageAsync();
    }
}
