using AIO.API.Bases;
using AIO.Contracts.Features.ProjectInsurances.Commands;
using AIO.Contracts.Features.ProjectInsurances.Queries;
using AIO.Contracts.Features.Projects.Commands;
using AIO.Contracts.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIO.API.Controllers.Admin.ProjectInsurances
{
    [Route("api/admin/[controller]")]
    [Authorize]
    [ApiController]
    public class ProjectInsurancesController : APIControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectInsurancesController(HolderOfDTO holderOfDTO, IMediator mediator) : base(holderOfDTO)
        {
            _mediator = mediator;

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ProjectInsurancesAddCommand request)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();


            return State(await _mediator.Send(request));
        }


        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] ProjectInsurancesUpdateCommand request)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();


            return State(await _mediator.Send(request));
        }


        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetAllProjectInsurancesQuery request)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();


            return State(await _mediator.Send(request));
        }

    }
}
