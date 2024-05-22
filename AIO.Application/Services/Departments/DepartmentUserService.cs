using AutoMapper;
using AIO.Contracts.DTOs.Getter.Departments.DepartmentUser;
using AIO.Contracts.DTOs.Setter.Departments.DepartmentUser;
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

namespace AIO.Application.Services.DepartmentUsers
{
    public class DepartmentUserService : BaseService<DepartmentUserService>, IDepartmentUserService
    {
        public DepartmentUserService(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<DepartmentUserService> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
        }

        public async Task<IHolderOfDTO> GetAllAdminAsync()
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var query = await _unitOfWork.DepartmentUser.FindAllAsync(new[] { "User", "Department" });
                _holderOfDTO.Add(Res.Response, _mapper.Map<IEnumerable<DepartmentUserGetterDTO>>(query.ToList()));
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
                var query = await _unitOfWork.DepartmentUser.FirstOrDefaultAsync(q => q.Id == id, new[] { "User", "Department" });
                if (query != null)
                {
                    _holderOfDTO.Add(Res.Response, _mapper.Map<DepartmentUserGetterDTO>(query));
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

        public async Task<IHolderOfDTO> SaveAsync(DepartmentUserSetterDTO setterDTO)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                if (!await _unitOfWork.DepartmentUser.CheckIfEntityExist(q => q.UserId == setterDTO.UserId && q.DepartmentId == setterDTO.DepartmentId))
                {

                    var dbSetterDTO = _mapper.Map<DepartmentUser>(setterDTO);
                    var oData = await _unitOfWork.DepartmentUser.AddAsync(dbSetterDTO);
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

        public async Task<IHolderOfDTO> SaveBatchAsync(DepartmentUserBatchSetterDTO setterDTO)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var deparrtmentUsers = new List<DepartmentUser>();
                foreach (var setter in setterDTO.Departments)
                {
                    if (!await _unitOfWork.DepartmentUser.CheckIfEntityExist(q => q.UserId == setterDTO.UserId && q.DepartmentId == setter.DepartmentId))
                    {
                        var dbSetterDTO = _mapper.Map<DepartmentUser>(setterDTO);
                        dbSetterDTO.IsManager = setter.IsManager;
                        dbSetterDTO.DepartmentId = setter.DepartmentId;
                        AddCreateData(dbSetterDTO);
                        deparrtmentUsers.Add(dbSetterDTO);
                    }
                }
                if (deparrtmentUsers.Count > 0)
                {
                    var oData = _unitOfWork.DepartmentUser.AddRange(deparrtmentUsers);
                    lIndicators.Add(_unitOfWork.Complete() > 0);
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

        public async Task<IHolderOfDTO> Update(DepartmentUserUpdateSetterDTO updateDTO)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var oldObj = _unitOfWork.DepartmentUser.FirstOrDefaultAsync(q => q.Id == updateDTO.Id).Result;
                if (oldObj != null)
                {
                    if (!(await _unitOfWork.DepartmentUser.CheckIfEntityExist(q => q.UserId == updateDTO.UserId && q.DepartmentId == updateDTO.DepartmentId))
                       || (await _unitOfWork.DepartmentUser.CheckIfEntityExist(q => q.UserId == updateDTO.UserId && q.DepartmentId == updateDTO.DepartmentId)
                       && await _unitOfWork.DepartmentUser.CheckIfEntityExist(q => q.Id == updateDTO.Id && q.UserId == updateDTO.UserId && q.DepartmentId == updateDTO.DepartmentId)))
                    {
                        var dbSetterDTO = _mapper.Map<DepartmentUser>(updateDTO);
                        var oData = await _unitOfWork.DepartmentUser.UpdateAsync(dbSetterDTO);
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
                var obj = _unitOfWork.DepartmentUser.FirstOrDefaultAsync(q => q.Id == id).Result;
                if (obj != null)
                {
                    _unitOfWork.DepartmentUser.Delete(id);
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
                var obj = await _unitOfWork.DepartmentUser.FirstOrDefaultAsync(q => q.Id == id);
                if (obj != null)
                {
                    await _unitOfWork.DepartmentUser.DeleteSoftAsync(obj);
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
                var obj = await _unitOfWork.DepartmentUser.FirstOrDefaultAsync(q => q.Id == id);
                if (obj != null)
                {
                    await _unitOfWork.DepartmentUser.CancelDeleteSoftAsync(obj);
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
    }
}
