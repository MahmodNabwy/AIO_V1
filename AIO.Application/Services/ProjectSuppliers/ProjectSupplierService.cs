using AIO.Application.Extentions;
using AIO.Application.Services.ProjectInsurances;
using AIO.Contracts.DTOs.Getter.ProjectSupplier;
using AIO.Contracts.Features.ProjectsSuppliers.Commands;
using AIO.Contracts.Features.ProjectsSuppliers.Queries;
using AIO.Contracts.Helpers;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.Interfaces.Services.ProjectInsurance;
using AIO.Contracts.Interfaces.Services.ProjectSupplier;
using AIO.Core.Bases;
using AIO.Core.Entities.ProjectInsurances;
using AIO.Core.Entities.ProjectPaymentMethods;
using AIO.Core.Entities.ProjectsSuppliersTaxes;
using AIO.Core.Entities.ProjectSuppliers;
using AIO.Core.Entities.SupplierInsurances;
using AIO.Core.Entities.SupplierPaymentMethods;
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

namespace AIO.Application.Services.ProjectSuppliers
{
    public class ProjectSupplierService : BaseService<ProjectSupplierService>, IProjectSupplierService
    {
        public ProjectSupplierService(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<ProjectSupplierService> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {

        }

        public async Task<IHolderOfDTO> SaveAsync(ProjectSupplierAddCommand setterDTO)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                if (setterDTO is not null)
                {

                    var oProjectSupplier = await _unitOfWork.ProjectSupplier.AddAsync(_mapper.Map<ProjectSupplier>(setterDTO.projectSupplierDataSetterDTO));
                    if (_unitOfWork.Complete() > 0)
                    {
                        var supplierProjectInsurancesList = _mapper.Map<IList<SupplierProjectInsurance>>(setterDTO.InsuranceConditions);
                        foreach (var item in supplierProjectInsurancesList)
                        {
                            item.ProjectId = setterDTO.projectSupplierDataSetterDTO.ProjectId;
                            item.SupplierId = setterDTO.projectSupplierDataSetterDTO.SupplierId;
                        }
                        var oSupplierProjectInsurances = await _unitOfWork.SupplierProjectInsurance.AddRangeAsync(supplierProjectInsurancesList);
                        _unitOfWork.Complete();


                        var supplierProjectPaymentMethodsList = _mapper.Map<IList<SupplierProjectPaymentMethod>>(setterDTO.PaymentMethods);
                        foreach (var item in supplierProjectPaymentMethodsList)
                        {
                            item.ProjectId = setterDTO.projectSupplierDataSetterDTO.ProjectId;
                            item.SupplierId = setterDTO.projectSupplierDataSetterDTO.SupplierId;


                        }

                        foreach (var item in setterDTO.TaxesIds)
                        {
                            ProjectSupplierTaxe oProjectSupplierTaxe = new ProjectSupplierTaxe();
                            oProjectSupplierTaxe.TaxId = item;
                            oProjectSupplierTaxe.SupplierId = setterDTO.projectSupplierDataSetterDTO.SupplierId;
                            oProjectSupplierTaxe.ProjectId = setterDTO.projectSupplierDataSetterDTO.ProjectId;

                            await _unitOfWork.ProjectSupplierTaxe.AddAsync(oProjectSupplierTaxe);
                            _unitOfWork.Complete();

                        }
                        var oSupplierProjectPaymentMethods = await _unitOfWork.SupplierProjectPaymentMethod.AddRangeAsync(supplierProjectPaymentMethodsList);
                        _unitOfWork.Complete();


                        _logger.LogInformation(Res.message, Res.Added);
                        _holderOfDTO.Add(Res.id, oProjectSupplier.Id);
                        _holderOfDTO.Add(Res.Response, setterDTO.projectSupplierDataSetterDTO);
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


        public async Task<IHolderOfDTO> GetAllAsync(GetProjectSuppliersQuery request)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {


                var query = _unitOfWork.ProjectSupplier.GetAll(request.ProjectId, request.TypeId);
                int totalCount = await query.CountAsync();
                var page = new Pager();
                page.Set(request.PageSize, request.CurrentPage, totalCount);
                _holderOfDTO.Add(Res.page, page);
                query = query.AddPage(page.Skip, page.PageSize);
                _holderOfDTO.Add(Res.Response, _mapper.Map<IEnumerable<ProjectSupplierDataDTO>>(query.ToList()));
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
