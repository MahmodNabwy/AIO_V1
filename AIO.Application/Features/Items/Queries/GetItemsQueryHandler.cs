using AIO.Application.Features.ProjectInsurances.Commands;
using AIO.Contracts.Features.Items.Queries;
using AIO.Contracts.Features.ProjectInsurances.Commands;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.Interfaces.Services.Items;
using AIO.Contracts.Interfaces.Services.ProjectInsurance;
using AIO.Core.Bases;
using AIO.Core.IServices.Custom;
using AIO.Shared.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Application.Features.Items.Queries
{
    public class GetItemsQueryHandler : BaseService<GetItemsQueryHandler>, IRequestHandler<GetItemsQuery, IHolderOfDTO>
    {
        private readonly IItemService _itemService;

        public GetItemsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<GetItemsQueryHandler> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor, IItemService itemService)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
            _itemService = itemService;
        }

        public async Task<IHolderOfDTO> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            return await _itemService.GetAllAsync();
        }
    }
}
