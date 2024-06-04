using AIO.API.Bases;
using AIO.Contracts.Features.ProjectPaymentMethod.Commands;
using AIO.Contracts.Features.ProjectPaymentMethod.Queries;
using AIO.Contracts.Features.ProjectTaxes.Commands;
using AIO.Contracts.Features.ProjectTaxes.Queries;
using AIO.Contracts.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIO.API.Controllers.Admin.ProjectTaxes
{
    [Route("api/admin/[controller]")]
    [Authorize]
    [ApiController]
    public class ProjectTaxesController : APIControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectTaxesController(HolderOfDTO holderOfDTO, IMediator mediator) : base(holderOfDTO)
        {
            _mediator = mediator;

        }
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] ProjectTaxesUpdateCommand request)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();


            return State(await _mediator.Send(request));
        }         

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetAllProjectTaxesQuery request)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();


            return State(await _mediator.Send(request));
        }

         
    }
}
