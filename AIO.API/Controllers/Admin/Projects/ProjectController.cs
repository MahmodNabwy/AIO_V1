using AIO.API.Bases;
using AIO.Contracts.DTOs.Setter.Projects;
using AIO.Contracts.Features.Projects.Commands;
using AIO.Contracts.Helpers;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.Interfaces.Services.IProjectServices;
using AIO.Contracts.IServices.Services.Departments;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIO.API.Controllers.Admin.Projects
{
    [Route("api/admin/[controller]")]
    [Authorize]
    [ApiController]
    public class ProjectController : APIControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(HolderOfDTO holderOfDTO,IMediator mediator) : base(holderOfDTO)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ProjectAddCommand request)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            
             
            return State(await _mediator.Send(request));
        }
    }
}
