using AutoMapper;
using AIO.Application.Extentions;
using AIO.Contracts.DTOs.Getter.Elements.Element;
using AIO.Contracts.DTOs.Setter.Elements.Element;
using AIO.Contracts.Filters;
using AIO.Contracts.Helpers;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.IServices.Services.Elements;
using AIO.Core.Bases;
using AIO.Core.Entities.Elements;
using AIO.Core.IServices.Custom;
using AIO.Shared.Consts;
using AIO.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AIO.Application.Services.Elements
{
    public class ElementService : BaseService<ElementService>, IElementService
    {

        public ElementService(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            IHostEnvironment environment, IHttpContextAccessor httpContextAccessor, ILogger<ElementService> logger)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
        }

        public async Task<IHolderOfDTO> GetAllAdminAsync(List<string> keys)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var query = await _unitOfWork.Elements.FindAllAsync(q => keys.Select(s => s).Contains(q.key), new[] { "ElementTranslations" });
                _holderOfDTO.Add(Res.Response, _mapper.Map<IEnumerable<ElementGetterDTO>>(query.ToList()));
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
        public async Task<IHolderOfDTO> GetAllAsync(List<string> keys)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var query = await _unitOfWork.Elements.FindAllAsync(q => keys.Select(s => s).Contains(q.key) && !q.IsDeleted, new[] { "ElementTranslations" });
                _holderOfDTO.Add(Res.Response, _mapper.Map<IEnumerable<ElementDataGetterDTO>>(query.ToList()));
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
                var query = _unitOfWork.Elements.Find(q => q.Id == id, new[] { "ElementTranslations" });
                _holderOfDTO.Add(Res.Response, _mapper.Map<ElementGetterDTO>(query));
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
        public async Task<IHolderOfDTO> GetByKeyAdminAsync(string key)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var query = _unitOfWork.Elements.Find(q => q.key == key, new[] { "ElementTranslations" });
                _holderOfDTO.Add(Res.Response, _mapper.Map<ElementGetterDTO>(query));
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
        public async Task<IHolderOfDTO> GetByKeyAsync(string key)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var query = _unitOfWork.Elements.Find(q => q.key == key && !q.IsDeleted, new[] { "ElementTranslations" });
                _holderOfDTO.Add(Res.Response, _mapper.Map<ElementDataGetterDTO>(query));
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
        public IHolderOfDTO SearchAdminAsync(ElementFilter filter)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var query = _unitOfWork.Elements.buildFilterAdminQuery(filter);
                int totalCount = query.Count();
                var page = new Pager();
                page.Set(filter.PageSize, filter.CurrentPage, totalCount);
                _holderOfDTO.Add(Res.page, page);
                query = query.AddPage(page.Skip, page.PageSize);
                _holderOfDTO.Add(Res.Response, _mapper.Map<IEnumerable<ElementGetterDTO>>(query.ToList()));
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
        public async Task<IHolderOfDTO> SaveAsync(ElementSetterDTO setterDTO)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                if (!await _unitOfWork.Elements.CheckIfEntityExist(q => q.key == setterDTO.key))
                {
                    var oData = await _unitOfWork.Elements.AddAsync(_mapper.Map<Element>(setterDTO));
                    lIndicators.Add(_unitOfWork.Complete() > 0);
                    _logger.LogInformation(Res.message, Res.Added);
                    _holderOfDTO.Add(Res.id, oData.Id);
                }
                else
                    ItemAlreadyFound(lIndicators);
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicators, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }
        public async Task<IHolderOfDTO> Update(ElementUpdateSetterDTO updateDTO)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var oldObj = _unitOfWork.Elements.Find(q => q.Id == updateDTO.Id);
                if (oldObj != null)
                {
                    if (!(await _unitOfWork.Elements.CheckIfEntityExist(q => q.key == updateDTO.key))
                       || (await _unitOfWork.Elements.CheckIfEntityExist(q => q.key == updateDTO.key)
                       && await _unitOfWork.Elements.CheckIfEntityExist(q => q.Id == updateDTO.Id && q.key == updateDTO.key)))
                    {
                        var dbSetterDTO = _mapper.Map<Element>(updateDTO);
                        dbSetterDTO.key = oldObj.key;
                        AddUpdateDefaultData(dbSetterDTO);
                        dbSetterDTO.ElementTranslations = UpdateRelatedData(dbSetterDTO.ElementTranslations, oldObj.Id);
                        if (dbSetterDTO.ElementTranslations.Count() > 0)
                            foreach (var item in dbSetterDTO.ElementTranslations)
                                AddUpdateTranslationDefaultData(item);
                        var oData = _unitOfWork.Elements.Update(dbSetterDTO);
                        lIndicators.Add(_unitOfWork.Complete() > 0);
                        _logger.LogInformation(Res.message, Res.Updated);
                        _holderOfDTO.Add(Res.id, oData.Id);
                    }
                    else
                        ItemAlreadyFound(lIndicators);
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
                var obj = _unitOfWork.Elements.Find(q => q.Id == id);
                if (obj != null)
                {
                    _unitOfWork.Elements.Delete(id);
                    lIndicators.Add(_unitOfWork.Complete() > 0);
                    _logger.LogInformation(Res.message, Res.Deleted);
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
                var oldObj = _unitOfWork.Elements.Find(q => q.Id == id);
                if (oldObj != null)
                {
                    AddUpdateData(oldObj);
                    await _unitOfWork.Elements.DeleteSoftAsync(oldObj);
                    lIndicators.Add(_unitOfWork.Complete() > 0);
                    _logger.LogInformation(Res.message, Res.SoftDeleted);
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
                var oldObj = _unitOfWork.Elements.Find(q => q.Id == id);
                if (oldObj != null)
                {
                    AddUpdateData(oldObj);
                    await _unitOfWork.Elements.CancelDeleteSoftAsync(oldObj);
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
        private ICollection<ElementTranslation> UpdateRelatedData(ICollection<ElementTranslation> ElementUpdate, long id)
        {
            var oldObj = _unitOfWork.ElementTranslations.FindAllNoTrack(q => q.ElementId == id);
            var updatedData = ElementUpdate.Where(q => q.Id != 0).ToList();
            RemoveRelatedData(oldObj, updatedData);
            AddNewRelatedData(ElementUpdate, id);
            return updatedData;
        }
        private void AddNewRelatedData(ICollection<ElementTranslation> newsUpdate, long id)
        {
            var NewData = newsUpdate.Where(q => q.Id == 0).ToList();
            foreach (var item in NewData)
            {
                AddCreateData(item);
                item.ElementId = id;
            }
            _unitOfWork.ElementTranslations.AddRange(NewData);
            _unitOfWork.Complete();
        }
        private void RemoveRelatedData(IEnumerable<ElementTranslation> oldObj, ICollection<ElementTranslation> updatedData)
        {
            var DeletedData = new List<ElementTranslation>();
            foreach (var item in oldObj)
            {
                var obj = updatedData.FirstOrDefault(q => q.Id == item.Id);
                if (obj == null)
                    DeletedData.Add(item);
            }
            if (DeletedData != null || DeletedData.Count() > 0)
            {
                _unitOfWork.ElementTranslations.DeleteRange(DeletedData);
                _unitOfWork.Complete();
            }
        }
        private void AddUpdateDefaultData(Element dbSetterDTO)
        {
            var oldObj = _unitOfWork.Elements.Find(q => q.Id == dbSetterDTO.Id);
            dbSetterDTO.CreatedBy = oldObj.CreatedBy;
            dbSetterDTO.CreatedAt = oldObj.CreatedAt;
            AddUpdateData(dbSetterDTO);
        }
        private void AddUpdateTranslationDefaultData(ElementTranslation dbSetterDTO)
        {
            var oldObj = _unitOfWork.ElementTranslations.Find(q => q.Id == dbSetterDTO.Id);
            dbSetterDTO.CreatedBy = oldObj.CreatedBy;
            dbSetterDTO.CreatedAt = oldObj.CreatedAt;
            AddUpdateData(dbSetterDTO);
        }
        #endregion
    }
}
