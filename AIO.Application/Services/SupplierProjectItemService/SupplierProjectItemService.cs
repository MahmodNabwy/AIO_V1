using AIO.Application.Services.ProjectSuppliers;
using AIO.Contracts.Features.SuppliersProjectsItems.Commands;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.Interfaces.Services.ProjectSupplier;
using AIO.Contracts.Interfaces.Services.SupplierProjectItemServices;
using AIO.Core.Bases;
using AIO.Core.Entities.ProjectAttachments;
using AIO.Core.Entities.ProjectInsurances;
using AIO.Core.Entities.ProjectPaymentMethods;
using AIO.Core.Entities.SupplierItems;
using AIO.Core.IServices.Custom;
using AIO.Shared.Consts;
using AIO.Shared.Interfaces;
using AutoMapper;
using Hangfire.Storage.Monitoring;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Application.Services.SupplierProjectItemService
{
    public class SupplierProjectItemService : BaseService<SupplierProjectItemService>, ISupplierProjectItemService
    {
        public SupplierProjectItemService(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<SupplierProjectItemService> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {

        }

        public async Task<IHolderOfDTO> SaveAsync(SupplierProjectItemsAddCommand request)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var oSupplierProjectItemsList = _mapper.Map<IList<SupplierProjectItem>>(request.items);
                var oSupplierProjectItems = await _unitOfWork.SupplierProjectItems.AddRangeAsync(oSupplierProjectItemsList);

                lIndicators.Add(_unitOfWork.Complete() > 0);
                _logger.LogInformation(Res.message, Res.Added);
                _holderOfDTO.Add(Res.id, oSupplierProjectItems);
                _holderOfDTO.Add(Res.Response, oSupplierProjectItems);


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
