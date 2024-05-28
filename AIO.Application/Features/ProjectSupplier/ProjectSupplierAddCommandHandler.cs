using AIO.Application.Features.Projects.Commands;
using AIO.Contracts.Features.Projects.Commands;
using AIO.Contracts.Features.ProjectsSuppliers.Commands;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.Interfaces.Services.IProjectServices;
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

namespace AIO.Application.Features.ProjectSupplier
{
    public class ProjectSupplierAddCommandHandler : BaseService<ProjectSupplierAddCommandHandler>, IRequestHandler<ProjectSupplierAddCommand, IHolderOfDTO>
    {
        private readonly IProjectService _projectService;

        public ProjectSupplierAddCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<ProjectSupplierAddCommandHandler> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor, IProjectService projectService)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
            _projectService = projectService;

        }
        public Task<IHolderOfDTO> Handle(ProjectSupplierAddCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
