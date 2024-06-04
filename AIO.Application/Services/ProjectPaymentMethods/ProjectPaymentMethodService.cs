using AIO.Application.Services.ProjectInsurances;
using AIO.Contracts.DTOs.Setter.ProjectPaymentMethod;
using AIO.Contracts.Features.ProjectInsurances.Commands;
using AIO.Contracts.Features.ProjectInsurances.Queries;
using AIO.Contracts.Features.ProjectPaymentMethod.Commands;
using AIO.Contracts.Features.ProjectPaymentMethod.Queries;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.Interfaces.Services.ProjectInsurance;
using AIO.Contracts.Interfaces.Services.ProjectPaymentMethods;
using AIO.Core.Bases;
using AIO.Core.Entities.ProjectInsurances;
using AIO.Core.Entities.ProjectPaymentMethods;
using AIO.Core.IServices.Custom;
using AIO.Shared.Consts;
using AIO.Shared.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Application.Services.ProjectPaymentMethods
{
    public class ProjectPaymentMethodService : BaseService<ProjectPaymentMethodService>, IProjectPaymentMethodService
    {
        public ProjectPaymentMethodService(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<ProjectPaymentMethodService> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
        }
        public async Task<IHolderOfDTO> SaveAsync(ProjectPaymentMethodAddCommand request)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var dbSetterDTO = _mapper.Map<ProjectPaymentMethod>(request);
                AddCreateData(dbSetterDTO);
                var oData = await _unitOfWork.ProjectPaymentMethod.AddAsync(dbSetterDTO);
                lIndicators.Add(_unitOfWork.Complete() > 0);
                _logger.LogInformation(Res.message, Res.Added);
                _logger.LogInformation(Res.id, oData.Id);

            }
            catch (Exception ex)
            {
                ExceptionError(lIndicators, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }

        public async Task<IHolderOfDTO> UpdateAsync(ProjectPaymentMethodUpdateCommand request)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var oldObj = await _unitOfWork.ProjectPaymentMethod.FirstOrDefaultAsync(q => q.Id == request.Id);

                if (oldObj != null)
                {
                    request.ProjectId = oldObj.ProjectId;
                    var dbSetterDTO = _mapper.Map<ProjectPaymentMethod>(request);
                    AddUpdateData(dbSetterDTO);
                    var oData = await _unitOfWork.ProjectPaymentMethod.UpdateAsync(dbSetterDTO);
                    lIndicators.Add(_unitOfWork.Complete() > 0);
                    _holderOfDTO.Add(Res.id, oData.Id);
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

        public async Task<IHolderOfDTO> GetAllAsync(GetAllProjectPaymentMethodsQuery request)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {

                var query = await _unitOfWork.ProjectPaymentMethod.GetListAsync(request.ProjectId);

                _holderOfDTO.Add(Res.Response, query);
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

        public async Task<IHolderOfDTO> DeleteAsync(int Id)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var obj = await _unitOfWork.ProjectPaymentMethod.FirstOrDefaultAsync(q => q.Id == Id);
                if (obj != null)
                {
                    _unitOfWork.ProjectPaymentMethod.Delete(obj);
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
    }
}
