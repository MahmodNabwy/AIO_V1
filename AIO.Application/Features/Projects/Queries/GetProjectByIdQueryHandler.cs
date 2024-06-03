﻿using AIO.Contracts.Features.Projects.Queries;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.Interfaces.Services.IProjectServices;
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

namespace AIO.Application.Features.Projects.Queries
{
    public class GetProjectByIdQueryHandler : BaseService<GetProjectByIdQueryHandler>, IRequestHandler<GetProjectByIdQuery, IHolderOfDTO>
    {
        private readonly IProjectService _projectService;

        public GetProjectByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture, IProjectService projectService,
            ILogger<GetProjectByIdQueryHandler> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
            _projectService = projectService;
        }
        public async Task<IHolderOfDTO> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            return await _projectService.GetByIdAsync(request);
        }
    }
}
