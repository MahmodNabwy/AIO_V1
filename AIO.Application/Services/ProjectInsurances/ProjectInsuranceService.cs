using AIO.Application.Extentions;
using AIO.Application.Services.Departments;
using AIO.Contracts.Features.ProjectInsurances.Commands;
using AIO.Contracts.Features.ProjectInsurances.Queries;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.Interfaces.Services.ProjectInsurance;
using AIO.Contracts.IServices.Services.Departments;
using AIO.Core.Bases;
using AIO.Core.Entities.ProjectInsurances;
using AIO.Core.IServices.Custom;
using AIO.Shared.Consts;
using AIO.Shared.Interfaces;
using AutoMapper;
using Hangfire.Storage.Monitoring;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Application.Services.ProjectInsurances
{
    public class ProjectInsuranceService : BaseService<ProjectInsuranceService>, IProjectInsuranceService
    {
        public ProjectInsuranceService(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<ProjectInsuranceService> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
        }

        public async Task<IHolderOfDTO> SaveAsync(ProjectInsurancesAddCommand request)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var dbSetterDTO = _mapper.Map<ProjectInsurance>(request);
                AddCreateData(dbSetterDTO);
                var oData = await _unitOfWork.ProjectInsurance.AddAsync(dbSetterDTO);
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

        public async Task<IHolderOfDTO> UpdateAsync(ProjectInsurancesUpdateCommand request)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var oldObj = await _unitOfWork.ProjectInsurance.FirstOrDefaultAsync(q => q.Id == request.Id);

                if (oldObj != null)
                {
                    request.ProjectId = oldObj.ProjectId;
                    var dbSetterDTO = _mapper.Map<ProjectInsurance>(request);
                    AddUpdateData(dbSetterDTO);
                    var oData = await _unitOfWork.ProjectInsurance.UpdateAsync(dbSetterDTO);
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

        public async Task<IHolderOfDTO> GetAllAsync(GetAllProjectInsurancesQuery request)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {

                var query = await _unitOfWork.ProjectInsurance.GetListAsync(request.ProjectId);

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
                var obj = await _unitOfWork.ProjectInsurance.FirstOrDefaultAsync(q => q.Id == Id);
                if (obj != null)
                {
                    _unitOfWork.ProjectInsurance.Delete(obj);
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
