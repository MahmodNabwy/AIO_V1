using AutoMapper;
using AIO.Application.Extentions;
using AIO.Contracts.DTOs.Getter.Departments.Department;
using AIO.Contracts.DTOs.Setter.Departments.Department;
using AIO.Contracts.Filters;
using AIO.Contracts.Helpers;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.IServices.Services.Departments;
using AIO.Core.Bases;
using AIO.Core.Entities.Departments;
using AIO.Core.IServices.Custom;
using AIO.Shared.Consts;
using AIO.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AIO.Application.Services.Departments
{
    public class DepartmentService : BaseService<DepartmentService>, IDepartmentService
    {
        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<DepartmentService> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
        }

        public async Task<IHolderOfDTO> GetAllAdminAsync()
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var query = _unitOfWork.Department.GetAllAdmin();
                _holderOfDTO.Add(Res.Response, _mapper.Map<IEnumerable<DepartmentGetterDTO>>(query.ToList()));
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

        public IHolderOfDTO SearchAdminAsync(DepartmentAdminFilter filter)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var query = _unitOfWork.Department.buildFilterAdminQuery(filter);
                int totalCount = query.Count();
                var page = new Pager();
                page.Set(filter.PageSize, filter.CurrentPage, totalCount);
                _holderOfDTO.Add(Res.page, page);
                query = query.AddPage(page.Skip, page.PageSize);
                _holderOfDTO.Add(Res.Response, _mapper.Map<IEnumerable<DepartmentGetterDTO>>(query.ToList()));
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
                var query = _unitOfWork.Department.GetByIdAdmin(id);
                if (query != null)
                {
                    _holderOfDTO.Add(Res.Response, _mapper.Map<DepartmentGetterDTO>(query));
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

        public async Task<IHolderOfDTO> SaveAsync(DepartmentSetterDTO setterDTO)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                if (!await _unitOfWork.Department.CheckIfEntityExist(q => q.Name == setterDTO.Name))
                {

                    var oData = await _unitOfWork.Department.AddAsync(_mapper.Map<Department>(setterDTO));
                    lIndicators.Add(_unitOfWork.Complete() > 0);
                    _holderOfDTO.Add(Res.id, oData.Id);
                    _logger.LogInformation(Res.message, Res.Added);
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

        public async Task<IHolderOfDTO> Update(DepartmentUpdateSetterDTO updateDTO)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var oldObj = _unitOfWork.Department.FirstOrDefaultAsync(q => q.Id == updateDTO.Id, new[] { "DepartmentTranslations" }).Result;
                if (oldObj != null)
                {
                    if (!(await _unitOfWork.Department.CheckIfEntityExist(q => q.Name == updateDTO.Name))
                       || (await _unitOfWork.Department.CheckIfEntityExist(q => q.Name == updateDTO.Name)
                       && await _unitOfWork.Department.CheckIfEntityExist(q => q.Id == updateDTO.Id && q.Name == updateDTO.Name)))
                    {
                        var dbSetterDTO = _mapper.Map<Department>(updateDTO);
                        dbSetterDTO.DepartmentTranslations = UpdateRelatedData(dbSetterDTO.DepartmentTranslations, oldObj.Id);
                        if (dbSetterDTO.DepartmentTranslations.Count() > 0)
                            foreach (var item in dbSetterDTO.DepartmentTranslations)
                                AddUpdateTranslationDefaultData(item);
                        var oData = await _unitOfWork.Department.UpdateAsync(dbSetterDTO);
                        lIndicators.Add(_unitOfWork.Complete() > 0);
                        _holderOfDTO.Add(Res.id, oData.Id);
                        _logger.LogInformation(Res.message, Res.Updated);
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

        public async Task<IHolderOfDTO> Delete(long id)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var obj = _unitOfWork.Department.FirstOrDefaultAsync(q => q.Id == id).Result;
                if (obj != null)
                {
                    _unitOfWork.Department.Delete(id);
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
                var obj = await _unitOfWork.Department.FirstOrDefaultAsync(q => q.Id == id);
                if (obj != null)
                {
                    AddUpdateData(obj);
                    await _unitOfWork.Department.DeleteSoftAsync(obj);
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
                var obj = await _unitOfWork.Department.FirstOrDefaultAsync(q => q.Id == id);
                if (obj != null)
                {
                    AddUpdateData(obj);
                    await _unitOfWork.Department.CancelDeleteSoftAsync(obj);
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
        private ICollection<DepartmentTranslation> UpdateRelatedData(ICollection<DepartmentTranslation> DepartmentUpdate, long id)
        {
            var oldObj = _unitOfWork.DepartmentTranslation.FindAllNoTrack(q => q.DepartmentId == id);
            var updatedData = DepartmentUpdate.Where(q => q.Id != 0).ToList();
            RemoveRelatedData(oldObj, updatedData);
            AddNewRelatedData(DepartmentUpdate, id);
            return updatedData;
        }
        private void AddNewRelatedData(ICollection<DepartmentTranslation> updatedData, long id)
        {
            var NewData = updatedData.Where(q => q.Id == 0).ToList();
            foreach (var item in NewData)
            {
                AddCreateData(item);
                item.DepartmentId = id;
            }
            _unitOfWork.DepartmentTranslation.AddRange(NewData);
            _unitOfWork.Complete();
        }
        private void RemoveRelatedData(IEnumerable<DepartmentTranslation> oldObj, ICollection<DepartmentTranslation> updatedData)
        {
            var DeletedData = new List<DepartmentTranslation>();
            foreach (var item in oldObj)
            {
                var obj = updatedData.FirstOrDefault(q => q.Id == item.Id);
                if (obj == null)
                    DeletedData.Add(item);
            }
            if (DeletedData != null || DeletedData.Count() > 0)
            {
                _unitOfWork.DepartmentTranslation.DeleteRange(DeletedData);
                _unitOfWork.Complete();
            }
        }
        private void AddUpdateTranslationDefaultData(DepartmentTranslation dbSetterDTO)
        {
            var oldObj = _unitOfWork.DepartmentTranslation.Find(q => q.Id == dbSetterDTO.Id);
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
