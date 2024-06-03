using AIO.Application.Features.Owners.Queries;
using AIO.Application.Features.Suppliers.Queries;
using AIO.Contracts.Features.Suppliers.Queries;
using AIO.Contracts.Features.Taxes.Queries;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.IServices.Services.Lookups;
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

namespace AIO.Application.Features.Taxes.Queries
{
    public class GetTaxesLookUpQueryHandler : BaseService<GetTaxesLookUpQueryHandler>, IRequestHandler<GetTaxesLookUpQuery, IHolderOfDTO>
    {
        private readonly ILookupService _lookupService;
        public GetTaxesLookUpQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture, ILookupService lookupService,
            ILogger<GetTaxesLookUpQueryHandler> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
            _lookupService = lookupService;
        }
        public async Task<IHolderOfDTO> Handle(GetTaxesLookUpQuery request, CancellationToken cancellationToken)
        {
            return await _lookupService.GetTaxesAsync();
        }
    }
}
