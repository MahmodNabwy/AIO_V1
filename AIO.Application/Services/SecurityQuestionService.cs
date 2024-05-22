using AutoMapper;
using AIO.Contracts.DTOs.Auth.Getter.SecurityQuestions;
using AIO.Contracts.DTOs.Setter.SecurityQuestions;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.IServices.Services.SecurityQuestions;
using AIO.Core.Bases;
using AIO.Core.Entities.SecurityQuestions;
using AIO.Core.IServices.Custom;
using AIO.Shared.Consts;
using AIO.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AIO.Application.Services
{
    public class SecurityQuestionService : BaseService<SecurityQuestionService>, ISecurityQuestionService
    {
        public SecurityQuestionService(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ILogger<SecurityQuestionService> logger, ICulture culture, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
        }

        public async Task<IHolderOfDTO> GetAllAsync()
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var query = await _unitOfWork.SecurityQuestions.GetAllAsync();
                int totalCount = query.Count();
                lIndicators.Add(true);


                _holderOfDTO.Add(Res.Response, _mapper.Map<IEnumerable<SecurityQuestionGetterDTO>>(query.ToList()));
                lIndicators.Add(true);
            }
            catch (Exception ex)
            {
                _holderOfDTO.Add(Res.message, ex.Message);
                lIndicators.Add(false);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }

        public async Task<IHolderOfDTO> GetByIdAsync(int id)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                _holderOfDTO.Add(Res.Response, _mapper.Map<SecurityQuestionGetterDTO>(await _unitOfWork.SecurityQuestions.FirstOrDefaultAsync(q => !q.IsDeleted && q.Id == id)));
                lIndicators.Add(true);
            }
            catch (Exception ex)
            {
                _holderOfDTO.Add(Res.message, ex.Message);
                lIndicators.Add(false);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }

        public async Task<IHolderOfDTO> SaveAsync(SecurityQuestionSetterDTO SecurityQuestionSetterDTO)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var oQuestion = await _unitOfWork.SecurityQuestions.AddAsync(_mapper.Map<SecurityQuestion>(SecurityQuestionSetterDTO));
                lIndicators.Add(_unitOfWork.Complete() > 0);
                _holderOfDTO.Add(Res.id, oQuestion.Id);
            }
            catch (Exception ex)
            {
                _holderOfDTO.Add(Res.message, ex.Message);
                lIndicators.Add(false);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }

        public IHolderOfDTO Update(SecurityQuestionSetterDTO SecurityQuestionSetterDTO)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var oQuestion = _unitOfWork.SecurityQuestions.Update(_mapper.Map<SecurityQuestion>(SecurityQuestionSetterDTO));
                lIndicators.Add(_unitOfWork.Complete() > 0);
                _holderOfDTO.Add(Res.id, oQuestion.Id);
            }
            catch (Exception ex)
            {
                _holderOfDTO.Add(Res.message, ex.Message);
                lIndicators.Add(false);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }

        public IHolderOfDTO Delete(long id)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                _unitOfWork.SecurityQuestions.Delete(id);
                lIndicators.Add(_unitOfWork.Complete() > 0);
            }
            catch (Exception ex)
            {
                _holderOfDTO.Add(Res.message, ex.Message);
                lIndicators.Add(false);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }

        public async Task<IHolderOfDTO> DeleteSoftAsync(long id)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var entityToDelete = await _unitOfWork.SecurityQuestions.FirstOrDefaultAsync(q => q.Id == id);
                if (entityToDelete != null)
                {
                    entityToDelete.UpdatedBy = GetUserId();
                    entityToDelete.UpdatedAt = DateTime.Now;
                    await _unitOfWork.SecurityQuestions.DeleteSoftAsync(entityToDelete);
                    lIndicators.Add(_unitOfWork.Complete() > 0);
                }
                else
                    lIndicators.Add(false);


            }
            catch (Exception ex)
            {
                _holderOfDTO.Add(Res.message, ex.Message);
                lIndicators.Add(false);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }

        public async Task<IHolderOfDTO> CancelDeleteSoftAsync(long id)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var entityToDelete = await _unitOfWork.SecurityQuestions.FirstOrDefaultAsync(q => q.Id == id);
                if (entityToDelete != null)
                {
                    entityToDelete.UpdatedBy = GetUserId();
                    entityToDelete.UpdatedAt = DateTime.Now;
                    await _unitOfWork.SecurityQuestions.DeleteSoftAsync(entityToDelete);
                    lIndicators.Add(_unitOfWork.Complete() > 0);
                }
                else
                    lIndicators.Add(false);
            }
            catch (Exception ex)
            {
                _holderOfDTO.Add(Res.message, ex.Message);
                lIndicators.Add(false);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }

    }
}
