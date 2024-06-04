
using AIO.Application.Extentions;
using AIO.Contracts.DTOs.Getter.ProjectSupplier;
using AIO.Contracts.DTOs.Setter.Projects;
using AIO.Contracts.Features.Projects.Commands;
using AIO.Contracts.Features.Projects.Queries;
using AIO.Contracts.Helpers;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.Interfaces.Services.IProjectServices;
using AIO.Core.Bases;
using AIO.Core.Entities.ProjectAttachments;
using AIO.Core.Entities.ProjectInsurances;
using AIO.Core.Entities.ProjectPaymentMethods;
using AIO.Core.Entities.Projects;
using AIO.Core.Entities.ProjectsTaxes;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Application.Services.ProjectServices
{
    public class ProjectService : BaseService<ProjectService>, IProjectService
    {
        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<ProjectService> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {

        }
        public async Task<IHolderOfDTO> AddNewProject(ProjectAddCommand setterDTO)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                if (setterDTO is not null)
                {
                    var oProject = await _unitOfWork.Projects.AddAsync(_mapper.Map<Project>(setterDTO.ProjectData));
                    if (_unitOfWork.Complete() > 0)
                    {
                        var ProjectId = oProject.Id;
                        // Add Project Insurnace Conditions
                        foreach (var item in setterDTO.InsuranceConditions)
                        {
                            item.ProjectId = ProjectId;
                        }
                        foreach (var item in setterDTO.ProjectPaymentMethods)
                        {
                            item.ProjectId = ProjectId;

                        }
                        foreach (var item in setterDTO.TaxeIds)
                        {
                            ProjectTaxe oProjectTaxes = new ProjectTaxe();
                            oProjectTaxes.ProjectId = ProjectId;
                            oProjectTaxes.TaxId = item;
                            await _unitOfWork.ProjectTaxes.AddAsync(oProjectTaxes);
                            _unitOfWork.Complete();

                        }
                        var projectsInsuranceList = _mapper.Map<IList<ProjectInsurance>>(setterDTO.InsuranceConditions);
                        var oProjectInsurances = await _unitOfWork.ProjectInsurance.AddRangeAsync(projectsInsuranceList);
                        _unitOfWork.Complete();

                        var projectPaymentMethodList = _mapper.Map<IList<ProjectPaymentMethod>>(setterDTO.ProjectPaymentMethods);
                        var oProjectPaymentMethods = await _unitOfWork.ProjectPaymentMethod.AddRangeAsync(projectPaymentMethodList);

                        lIndicators.Add(_unitOfWork.Complete() > 0);
                        _logger.LogInformation(Res.message, Res.Added);
                        _holderOfDTO.Add(Res.id, oProject.Id);
                        _holderOfDTO.Add(Res.Response, setterDTO.ProjectData);
                    }



                }
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicators, ex.Message);

            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }

        public async Task<IHolderOfDTO> GetAllAsync(GetAllProjectsQuery request)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {


                var query = _unitOfWork.Projects.GetAll();
                int totalCount = await query.CountAsync();
                var page = new Pager();
                page.Set(request.PageSize, request.CurrentPage, totalCount);
                _holderOfDTO.Add(Res.page, page);
                query = query.AddPage(page.Skip, page.PageSize);
                _holderOfDTO.Add(Res.Response, query.ToList());
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

        public async Task<IHolderOfDTO> SearchAsync(GetProjectsSearchQuery filter)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var query = _unitOfWork.Projects.buildFilterQuery(filter);
                int totalCount = await query.CountAsync();
                var page = new Pager();
                page.Set(filter.PageSize, filter.CurrentPage, totalCount);
                _holderOfDTO.Add(Res.page, page);
                query = query.AddPage(page.Skip, page.PageSize);
                _holderOfDTO.Add(Res.Response, query.ToList());
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

        public async Task<IHolderOfDTO> ConfirmProjectAsync(int projectId)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {


                var oProject = await _unitOfWork.Projects.FirstOrDefaultAsync(c => c.Id == projectId);
                if (oProject is not null)
                {
                    oProject.IsConfirmed = true;
                    await _unitOfWork.Projects.UpdateAsync(oProject);
                    lIndicators.Add(_unitOfWork.Complete() > 0);
                    _logger.LogInformation(Res.message, Res.Updated);
                    _holderOfDTO.Add(Res.id, oProject.Id);

                }
                else
                {
                    lIndicators.Add(false);
                    _logger.LogInformation(Res.error, Res.error);
                    NotFoundError(lIndicators);
                }


            }
            catch (Exception ex)
            {
                ExceptionError(lIndicators, ex.Message);

            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }

        public async Task<IHolderOfDTO> GetByIdAsync(GetProjectByIdQuery request)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var query = await _unitOfWork.Projects.GetByIdAsync(request);
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


        public async Task<IHolderOfDTO> UpdateAsync(ProjectUpdateCommand request)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var oldObj = await _unitOfWork.Projects.FirstOrDefaultAsync(q => q.Id == request.Id);

                if (oldObj != null)
                {
                    if (request.HasDiscount == false)
                        request.TotalPriceAfterDiscount = null;

                    var dbSetterDTO = _mapper.Map<Project>(request);
                    AddUpdateData(dbSetterDTO);
                    var oData = await _unitOfWork.Projects.UpdateAsync(dbSetterDTO);
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
    }
}
