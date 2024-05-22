using AutoMapper;
using AIO.Contracts.DTOs.Setter.Languages.Language;
using AIO.Contracts.Features.Languages.DTOs.Getter.Language;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.IServices.Services.Languages;
using AIO.Core.Bases;
using AIO.Core.Entities.Languages;
using AIO.Core.IServices.Custom;
using AIO.Shared.Consts;
using AIO.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AIO.Application.Services.Languages
{
    public class LanguageService : BaseService<LanguageService>, ILanguageService
    {
        public LanguageService(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<LanguageService> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
        }

        public async Task<IHolderOfDTO> GetAllAdminAsync()
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var query = await _unitOfWork.Language.FindAllAsync(new[] { "LanguageTranslations" });
                _holderOfDTO.Add(Res.Response, _mapper.Map<IEnumerable<LanguageGetterDTO>>(query.ToList()));
                _logger.LogInformation(Res.message, Res.DataFetch);
                lIndicators.Add(true);
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicators, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }

        public async Task<IHolderOfDTO> GetByIdAdminAsync(long id)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var query = await _unitOfWork.Language.FirstOrDefaultAsync(q => q.Id == id, new[] { "LanguageTranslations" });
                if (query != null)
                {
                    _holderOfDTO.Add(Res.Response, _mapper.Map<LanguageGetterDTO>(query));
                    _logger.LogInformation(Res.message, Res.DataFetch);
                    lIndicators.Add(true);
                }
                else
                    NotFoundError(lIndicators);
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicators, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }

        public async Task<IHolderOfDTO> GetAllAsync()
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var query = await _unitOfWork.Language.FindAll(q => !q.IsDeleted, new[] { "LanguageTranslations" });
                _holderOfDTO.Add(Res.Response, _mapper.Map<IEnumerable<LanguageDataGetterDTO>>(query.ToList()));
                _logger.LogInformation(Res.message, Res.DataFetch);
                lIndicators.Add(true);
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicators, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }

        public async Task<IHolderOfDTO> GetByIdAsync(long id)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var query = await _unitOfWork.Language.FirstOrDefaultAsync(q => !q.IsDeleted && q.Id == id, new[] { "LanguageTranslations" });
                if (query != null)
                {
                    _holderOfDTO.Add(Res.Response, _mapper.Map<LanguageDataGetterDTO>(query));
                    _logger.LogInformation(Res.message, Res.DataFetch);
                    lIndicators.Add(true);
                }
                else
                    NotFoundError(lIndicators);
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicators, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }
        public async Task<IHolderOfDTO> SaveAsync(LanguageSetterDTO setterDTO)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var oData = await _unitOfWork.Language.AddAsync(_mapper.Map<Language>(setterDTO));
                lIndicators.Add(_unitOfWork.Complete() > 0);
                _holderOfDTO.Add(Res.id, oData.Id);
                _logger.LogInformation(Res.message, Res.Added);
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicators, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }

        public async Task<IHolderOfDTO> Update(LanguageUpdateSetterDTO updateDTO)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var oldObj = _unitOfWork.Language.Find(q => q.Id == updateDTO.Id);
                if (oldObj != null)
                {

                    var dbSetterDTO = _mapper.Map<Language>(updateDTO);
                    dbSetterDTO.LanguageTranslations = UpdateRelatedData(dbSetterDTO.LanguageTranslations, oldObj.Id);
                    if (dbSetterDTO.LanguageTranslations.Count() > 0)
                        foreach (var translation in dbSetterDTO.LanguageTranslations)
                            AddUpdateTranslationDefaultData(translation);
                    var oData = await _unitOfWork.Language.UpdateAsync(dbSetterDTO);
                    lIndicators.Add(_unitOfWork.Complete() > 0);
                    _holderOfDTO.Add(Res.Response, _mapper.Map<LanguageDataGetterDTO>(oData));
                    _logger.LogInformation(Res.message, Res.Updated);
                }
                else
                    NotFoundError(lIndicators);
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicators, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }

        public IHolderOfDTO Delete(long id)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var obj = _unitOfWork.Language.FirstOrDefaultAsync(q => q.Id == id).Result;
                if (obj != null)
                {
                    if (!obj.IsDefault)
                    {
                        if (!obj.IsSystem)
                        {
                            _unitOfWork.Language.Delete(id);
                            lIndicators.Add(_unitOfWork.Complete() > 0);
                            _logger.LogInformation(Res.message, Res.Deleted);
                        }
                        ErrorMessage(lIndicators, Res.CannotDeleteSystemData);
                    }
                    else
                        ErrorMessage(lIndicators, Res.CannotDeleteLanguage);
                }
                else
                    NotFoundError(lIndicators);
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicators, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }

        public async Task<IHolderOfDTO> DeleteSoftAsync(long id)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var obj = await _unitOfWork.Language.FirstOrDefaultAsync(q => q.Id == id);
                if (obj != null)
                {
                    if (!obj.IsDefault)
                    {
                        await _unitOfWork.Language.DeleteSoftAsync(obj);
                        lIndicators.Add(_unitOfWork.Complete() > 0);
                        _logger.LogInformation(Res.message, Res.SoftDeleted);
                    }
                    else
                    {
                        _holderOfDTO.Add(Res.message, Res.CannotSoftDeleteLanguage);
                        _logger.LogError(Res.message, Res.CannotSoftDeleteLanguage);
                        lIndicators.Add(false);
                    }
                }
                else
                    NotFoundError(lIndicators);
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicators, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }

        public async Task<IHolderOfDTO> CancelDeleteSoftAsync(long id)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var obj = await _unitOfWork.Language.FirstOrDefaultAsync(q => q.Id == id);
                if (obj != null)
                {
                    await _unitOfWork.Language.CancelDeleteSoftAsync(obj);
                    lIndicators.Add(_unitOfWork.Complete() > 0);
                    _logger.LogInformation(Res.message, Res.cancelSoftDeleted);
                }
                else
                    NotFoundError(lIndicators);
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicators, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }

        #region Helper Method
        private ICollection<LanguageTranslation> UpdateRelatedData(ICollection<LanguageTranslation> LanguageUpdate, int id)
        {
            var oldObj = _unitOfWork.LanguageTranslation.FindAllNoTrack(q => q.LanguageId == id);
            var updatedData = LanguageUpdate.Where(q => q.Id != 0).ToList();
            RemoveRelatedData(oldObj, updatedData);
            AddNewRelatedData(LanguageUpdate, id);
            return updatedData;
        }
        private void AddNewRelatedData(ICollection<LanguageTranslation> newsUpdate, int id)
        {
            var NewData = newsUpdate.Where(q => q.Id == 0).ToList();
            foreach (var item in NewData)
            {
                AddCreateData(item);
                item.LanguageId = id;
            }
            _unitOfWork.LanguageTranslation.AddRange(NewData);
            _unitOfWork.Complete();
        }
        private void RemoveRelatedData(IEnumerable<LanguageTranslation> oldObj, ICollection<LanguageTranslation> updatedData)
        {
            var DeletedData = new List<LanguageTranslation>();
            foreach (var item in oldObj)
            {
                var obj = updatedData.FirstOrDefault(q => q.Id == item.Id);
                if (obj == null)
                    DeletedData.Add(item);
            }
            if (DeletedData != null || DeletedData.Count() > 0)
            {
                _unitOfWork.LanguageTranslation.DeleteRange(DeletedData);
                _unitOfWork.Complete();
            }
        }
        private void AddUpdateTranslationDefaultData(LanguageTranslation dbSetterDTO)
        {
            var oldObj = _unitOfWork.LanguageTranslation.Find(q => q.Id == dbSetterDTO.Id);
            if (oldObj != null)
            {
                dbSetterDTO.CreatedBy = oldObj.CreatedBy;
                dbSetterDTO.CreatedAt = oldObj.CreatedAt;
                AddUpdateData(dbSetterDTO);
            }
        }
        #endregion
    }
}
