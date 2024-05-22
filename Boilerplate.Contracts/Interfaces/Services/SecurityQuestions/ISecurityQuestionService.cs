using Boilerplate.Contracts.DTOs.Setter.SecurityQuestions;
using Boilerplate.Contracts.Interfaces.Custom;

namespace Boilerplate.Contracts.IServices.Services.SecurityQuestions
{
    public interface ISecurityQuestionService
    {
        public Task<IHolderOfDTO> GetAllAsync();
        public Task<IHolderOfDTO> GetByIdAsync(int id);
        public Task<IHolderOfDTO> SaveAsync(SecurityQuestionSetterDTO SecurityQuestionSetterDTO);
        public IHolderOfDTO Update(SecurityQuestionSetterDTO SecurityQuestionSetterDTO);
        public IHolderOfDTO Delete(long id);
        public Task<IHolderOfDTO> DeleteSoftAsync(long id);
        public Task<IHolderOfDTO> CancelDeleteSoftAsync(long id);
    }
}
