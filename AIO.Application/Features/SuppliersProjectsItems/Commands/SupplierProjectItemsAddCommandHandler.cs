using AIO.Application.Features.Projects.Commands;
using AIO.Contracts.Features.Projects.Commands;
using AIO.Contracts.Features.SuppliersProjectsItems.Commands;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.Interfaces.Services.IProjectServices;
using AIO.Contracts.Interfaces.Services.SupplierProjectItemServices;
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

namespace AIO.Application.Features.SuppliersProjectsItems.Commands
{
    public class SupplierProjectItemsAddCommandHandler : BaseService<SupplierProjectItemsAddCommandHandler>, IRequestHandler<SupplierProjectItemsAddCommand, IHolderOfDTO>
    {
        private readonly ISupplierProjectItemService _supplierProjectItem;

        public SupplierProjectItemsAddCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<SupplierProjectItemsAddCommandHandler> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor, ISupplierProjectItemService supplierProjectItemSerivce)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
            _supplierProjectItem = supplierProjectItemSerivce;
        }
         

        public async Task<IHolderOfDTO> Handle(SupplierProjectItemsAddCommand request, CancellationToken cancellationToken)
        {
            return await _supplierProjectItem.SaveAsync(request);
        }
    }
}
