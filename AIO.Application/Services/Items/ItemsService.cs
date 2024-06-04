using AIO.Application.Services.ProjectInsurances;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.Interfaces.Services.Items;
using AIO.Contracts.Interfaces.Services.ProjectInsurance;
using AIO.Core.Bases;
using AIO.Core.IServices.Custom;
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

namespace AIO.Application.Services.Items
{
    public class ItemsService : BaseService<ItemsService>, IItemService
    {
        public ItemsService(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<ItemsService> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
        }
    }
}
