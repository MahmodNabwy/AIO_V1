using AIO.API.Bases;
using AIO.Contracts.Features.Projects.Commands;
using AIO.Contracts.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIO.API.Controllers.Admin.ProjectsSuppliers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProjectsSuppliersController : APIControllerBase
    {
        private readonly IMediator _mediator;
        public ProjectsSuppliersController(HolderOfDTO holderOfDTO, IMediator mediator) : base(holderOfDTO)
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
