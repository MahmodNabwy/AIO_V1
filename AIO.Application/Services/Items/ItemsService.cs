using AIO.Application.Services.ProjectInsurances;
using AIO.Contracts.Features.Items.Commands;
using AIO.Contracts.Features.ProjectInsurances.Commands;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.Interfaces.Services.Items;
using AIO.Contracts.Interfaces.Services.ProjectInsurance;
using AIO.Core.Bases;
using AIO.Core.Entities.Items;
using AIO.Core.Entities.ProjectInsurances;
using AIO.Core.IServices.Custom;
using AIO.Shared.Consts;
using AIO.Shared.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Application.Services.Items
{
    public class ItemsService : BaseService<ItemsService>, IItemService
    {
        public ItemsService(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<ItemsService> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
        }

        public async Task<IHolderOfDTO> GetAllAsync()
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var query = await _unitOfWork.Items.GetAllAsync();
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


        public async Task<IHolderOfDTO> SaveAsync(ItemsAddCommand request)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var dbSetterDTO = _mapper.Map<Item>(request);
                AddCreateData(dbSetterDTO);
                var oData = await _unitOfWork.Items.AddAsync(dbSetterDTO);
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
    }
}
