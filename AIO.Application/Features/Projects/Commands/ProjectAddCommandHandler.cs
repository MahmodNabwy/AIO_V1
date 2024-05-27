﻿using AIO.Contracts.Features.Projects.Commands;
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

namespace AIO.Application.Features.Projects.Commands
{
    public class ProjectAddCommandHandler : BaseService<ProjectAddCommandHandler>, IRequestHandler<ProjectAddCommand, IHolderOfDTO>
    {
        private readonly IProjectService _projectService;

        public ProjectAddCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<ProjectAddCommandHandler> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor, IProjectService projectService)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
            _projectService = projectService;
        }

        public async Task<IHolderOfDTO> Handle(ProjectAddCommand request, CancellationToken cancellationToken)
        {
            return await _projectService.AddNewProject(request);
        }
    }
}
