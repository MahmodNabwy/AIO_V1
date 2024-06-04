using AIO.API.Bases;
using AIO.Contracts.Features.ProjectInsurances.Commands;
using AIO.Contracts.Features.ProjectInsurances.Queries;
using AIO.Contracts.Features.ProjectPaymentMethod.Commands;
using AIO.Contracts.Features.ProjectPaymentMethod.Queries;
using AIO.Contracts.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIO.API.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [Authorize]
    [ApiController]
    public class ProjectPaymentMethodController : APIControllerBase
    {
        private readonly IMediator _mediator;
        public ProjectPaymentMethodController(HolderOfDTO holderOfDTO, IMediator mediator) : base(holderOfDTO)
        {
            _mediator = mediator;

        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ProjectPaymentMethodAddCommand request)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();


            return State(await _mediator.Send(request));
        }


        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] ProjectPaymentMethodUpdateCommand request)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();


            return State(await _mediator.Send(request));
        }


        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetAllProjectPaymentMethodsQuery request)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();


            return State(await _mediator.Send(request));
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromQuery] ProjectPaymentMethodDeleteCommand request)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();


            return State(await _mediator.Send(request));
        }
    }
}
