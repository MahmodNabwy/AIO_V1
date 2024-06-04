using AIO.API.Bases;
using AIO.Contracts.Features.Items.Commands;
using AIO.Contracts.Features.Items.Queries;
using AIO.Contracts.Features.ProjectInsurances.Commands;
using AIO.Contracts.Features.ProjectInsurances.Queries;
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
    public class ItemsController : APIControllerBase
    {
        private readonly IMediator _mediator;

        public ItemsController(HolderOfDTO holderOfDTO, IMediator mediator) : base(holderOfDTO)
        {
            _mediator = mediator;

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ItemsAddCommand request)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();


            return State(await _mediator.Send(request));
        }


        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            if (!ModelState.IsValid)
                return NotValidModelState();


            return State(await _mediator.Send(new GetItemsQuery()));
        }

    }
}
