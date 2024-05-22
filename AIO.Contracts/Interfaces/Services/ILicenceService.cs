using AIO.Contracts.DTOs;
using AIO.Contracts.DTOs.Auth.Setter;
using AIO.Contracts.Interfaces.Custom;

namespace AIO.Contracts.IServices.Services
{
    public interface ILicenceService
    {
        public Task<Key> GetValidLicence(string Licence);
        public Task<IHolderOfDTO> GetLicence();
        public Task<IHolderOfDTO> SaveAsync(LicenceSetterDTO LicenceSetterDTO);
        public IHolderOfDTO Update(LicenceSetterDTO LicenceSetterDTO);
        public IHolderOfDTO Delete();
        public Task<bool> SaveTimeLogAsync();
        public Task<bool> CheckLicenceTime(Key key);
    }
}
