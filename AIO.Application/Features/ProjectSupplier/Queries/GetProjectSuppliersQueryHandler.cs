using AIO.Application.Features.Projects.Queries;
using AIO.Contracts.Features.Projects.Queries;
using AIO.Contracts.Features.ProjectsSuppliers.Queries;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.Interfaces.Services.ProjectSupplier;
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

namespace AIO.Application.Features.ProjectSupplier.Queries
{
    public class GetProjectSuppliersQueryHandler : BaseService<GetProjectSuppliersQueryHandler>, IRequestHandler<GetProjectSuppliersQuery, IHolderOfDTO>
    {
        private readonly IProjectSupplierService _projectSupplierService;

        public GetProjectSuppliersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture, IProjectSupplierService projectSupplierService,
            ILogger<GetProjectSuppliersQueryHandler> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
            _projectSupplierService = projectSupplierService;
        }
        public async Task<IHolderOfDTO> Handle(GetProjectSuppliersQuery request, CancellationToken cancellationToken)
        {
            var result = await _projectSupplierService.GetAllAsync(request);
            return result;
        }
    }
}
