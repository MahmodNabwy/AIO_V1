using AIO.Application.Services.ProjectServices;
using AIO.Contracts.Features.ProjectTaxes.Commands;
using AIO.Contracts.Features.ProjectTaxes.Queries;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.Interfaces.Services.IProjectServices;
using AIO.Contracts.Interfaces.Services.ProjectTaxes;
using AIO.Core.Bases;
using AIO.Core.Entities.ProjectPaymentMethods;
using AIO.Core.Entities.ProjectsTaxes;
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

namespace AIO.Application.Services.ProjectTaxes
{
    public class ProjectTaxesService : BaseService<ProjectTaxesService>, IProjectTaxesService
    {
        public ProjectTaxesService(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<ProjectTaxesService> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {

        }
        public async Task<IHolderOfDTO> UpdateAsync(ProjectTaxesUpdateCommand request)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var oldObj = await _unitOfWork.ProjectTaxes.FindAllAsync(q => q.ProjectId == request.ProjectId);
                var projectId = request.ProjectId;

                if (oldObj.Any())
                {

                    _unitOfWork.ProjectTaxes.DeleteRange(oldObj);
                    if (_unitOfWork.Complete() > 0)
                    {
                        if (request.TaxesIds.Count > 0)
                        {

                            foreach (var item in request.TaxesIds)
                            {
                                ProjectTaxe oProjectTaxe = new ProjectTaxe();
                                oProjectTaxe.ProjectId = projectId;
                                oProjectTaxe.TaxId = item;
                                var oData = await _unitOfWork.ProjectTaxes.AddAsync(oProjectTaxe);
                                _unitOfWork.Complete();

                            }
                            lIndicators.Add(true);
                            _logger.LogInformation(Res.message, Res.Updated);
                        }
                        else
                        {
                            var oProject = await _unitOfWork.Projects.FirstOrDefaultAsync(c => c.Id == projectId);
                            if (oProject is not null)
                            {
                                oProject.IncludeTaxes = false;
                                await _unitOfWork.Projects.UpdateAsync(oProject);
                                _unitOfWork.Complete();
                                lIndicators.Add(true);
                                _logger.LogInformation(Res.message, Res.Updated);

                            }
                            else
                            {
                                lIndicators.Add(false);
                                NotFoundError(lIndicators);

                            }
                        }
                    }
                }
                else
                {
                    foreach (var item in request.TaxesIds)
                    {
                        ProjectTaxe oProjectTaxe = new ProjectTaxe();
                        oProjectTaxe.ProjectId = projectId;
                        oProjectTaxe.TaxId = item;
                        var oData = await _unitOfWork.ProjectTaxes.AddAsync(oProjectTaxe);
                        _unitOfWork.Complete();

                    }
                    lIndicators.Add(true);
                    _logger.LogInformation(Res.message, Res.Updated);
                }

            }
            catch (Exception ex)
            {
                ExceptionError(lIndicators, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }

        public async Task<IHolderOfDTO> GetAllAsync(GetAllProjectTaxesQuery request)
        {

            List<bool> lIndicators = new List<bool>();
            try
            {

                var query = await _unitOfWork.ProjectTaxes.GetListAsync(request.ProjectId);

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
    }
}
