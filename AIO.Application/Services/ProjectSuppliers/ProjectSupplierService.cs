using AIO.Application.Services.ProjectInsurances;
using AIO.Contracts.Features.ProjectsSuppliers.Commands;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.Interfaces.Services.ProjectInsurance;
using AIO.Contracts.Interfaces.Services.ProjectSupplier;
using AIO.Core.Bases;
using AIO.Core.Entities.ProjectInsurances;
using AIO.Core.Entities.ProjectPaymentMethods;
using AIO.Core.Entities.ProjectSuppliers;
using AIO.Core.Entities.SupplierInsurances;
using AIO.Core.Entities.SupplierPaymentMethods;
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
                        var oSupplierProjectInsurances = await _unitOfWork.SupplierProjectInsurance.AddRangeAsync(supplierProjectInsurancesList);
                        _unitOfWork.Complete();


                        var supplierProjectPaymentMethodsList = _mapper.Map<IList<SupplierProjectPaymentMethod>>(setterDTO.PaymentMethods);
                        var oSupplierProjectPaymentMethods= await _unitOfWork.SupplierProjectPaymentMethod.AddRangeAsync(supplierProjectPaymentMethodsList);
                        _unitOfWork.Complete();


                        lIndicators.Add(_unitOfWork.Complete() > 0);
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
    }
}
