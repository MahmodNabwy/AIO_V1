using AIO.Application.Features.ProjectInsurances.Commands;
using AIO.Contracts.Features.Items.Commands;
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

namespace AIO.Application.Features.Items.Commands
{
    public class ItemsAddCommandHandler : BaseService<ItemsAddCommandHandler>, IRequestHandler<ItemsAddCommand, IHolderOfDTO>
    {
        private readonly IItemService _itemService;

        public ItemsAddCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<ItemsAddCommandHandler> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor, IItemService itemService)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
            _itemService = itemService;
        }

        public async Task<IHolderOfDTO> Handle(ItemsAddCommand request, CancellationToken cancellationToken)
        {
            return await _itemService.SaveAsync(request);
        }
    }
}
