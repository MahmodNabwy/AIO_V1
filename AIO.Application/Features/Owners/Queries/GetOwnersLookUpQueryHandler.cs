using AIO.Contracts.Features.Owners.Queries;
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

namespace AIO.Application.Features.Owners.Queries
{
    public class GetOwnersLookUpQueryHandler : BaseService<GetOwnersLookUpQueryHandler>, IRequestHandler<GetOwnersLookUpQuery, IHolderOfDTO>
    {
        private readonly ILookupService _lookupService;

        public GetOwnersLookUpQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture, ILookupService lookupService,
            ILogger<GetOwnersLookUpQueryHandler> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
            _lookupService = lookupService;
        }
        public async Task<IHolderOfDTO> Handle(GetOwnersLookUpQuery request, CancellationToken cancellationToken)
        {
            return await _lookupService.GetOwnersAsync();

        }
    }
}
