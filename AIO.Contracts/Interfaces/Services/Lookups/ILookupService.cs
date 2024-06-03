using AIO.Contracts.Features.Suppliers.Queries;
using AIO.Contracts.Interfaces.Custom;

namespace AIO.Contracts.IServices.Services.Lookups
{
    public interface ILookupService
    {

        Task<IHolderOfDTO> GetDepartmnetsAsync();
        Task<IHolderOfDTO> GetUserAsync();
        Task<IHolderOfDTO> GetRoleAsync();
        Task<IHolderOfDTO> GetLanguageAsync();
        Task<IHolderOfDTO> GetOwnersAsync();
        Task<IHolderOfDTO> GetProjectsAsync();
        Task<IHolderOfDTO> GetTaxesAsync();
        Task<IHolderOfDTO> GetSuppliersAsync(GetSupplierLookUpQuery request);
    }
}
