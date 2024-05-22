using AutoMapper;
using AIO.Contracts.DTOs.Getter.AppSettings;
using AIO.Contracts.DTOs.Setter.AppSettings;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.IServices.Services.AppSettings;
using AIO.Core.Bases;
using AIO.Core.Entities.AppSettings;
using AIO.Core.IServices.Custom;
using AIO.Shared.Consts;
using AIO.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AIO.Application.Services.AppSettings
{
    public class AppSettingService : BaseService<AppSetting>, IAppSettingService
    {
        public AppSettingService(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ILogger<AppSetting> logger = null, ICulture culture = null, IHostEnvironment environment = null, IHttpContextAccessor HttpContextAccessor = null)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, HttpContextAccessor)
        {
        }

        public async Task<IHolderOfDTO> GetAllAsync()
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var query = await _unitOfWork.AppSettings.FindAllAsync();
                _holderOfDTO.Add(Res.Response, _mapper.Map<IEnumerable<AppSettingGetterDTO>>(query.ToList()));

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
                var query = await _unitOfWork.AppSettings.FindAsync(q => q.Id == id);
                if (query != null)
                {
                    _holderOfDTO.Add(Res.Response, _mapper.Map<AppSettingGetterDTO>(query));
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
        public async Task<IHolderOfDTO> SaveAsync(AppSettingSetterDTO AppSettingSetterDTO)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                if (!await _unitOfWork.AppSettings.CheckIfEntityExist(q => q.Key == AppSettingSetterDTO.Key))
                {
                    var oData = await _unitOfWork.AppSettings.AddAsync(_mapper.Map<AppSetting>(AppSettingSetterDTO));
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

        public async Task<IHolderOfDTO> UpdateAsync(AppSettingUpdateSetterDTO updateDTO)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var oldObj = await _unitOfWork.AppSettings.FirstOrDefaultAsync(q => q.Id == updateDTO.Id, disableTracking: false);
                if (oldObj != null)
                {
                    if (!(await _unitOfWork.AppSettings.CheckIfEntityExist(q => q.Key == updateDTO.Key))
                        || (await _unitOfWork.AppSettings.CheckIfEntityExist(q => q.Key == updateDTO.Key)
                        && await _unitOfWork.AppSettings.CheckIfEntityExist(q => q.Id == updateDTO.Id && q.Key == updateDTO.Key)))
                    {
                        oldObj.Value = updateDTO.Value;
                        var oRegionalOfficeType = await _unitOfWork.AppSettings.UpdateAsync(oldObj);
                        lIndicators.Add(_unitOfWork.Complete() > 0);
                        _holderOfDTO.Add(Res.id, oRegionalOfficeType.Id);
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
    }
}
