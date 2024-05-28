using AIO.API.Bases;
using AIO.Contracts.Features.Owners.Queries;
using AIO.Contracts.Features.Projects.Commands;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.IServices.Services.Lookups;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AIO.API.Controllers.Admin.Lookups
{
    [Authorize]
    [Route("api/admin/[controller]")]
    [ApiController]
    public class LookupController : APIControllerBase
    {
        private readonly IMediator _mediator;


        public LookupController(IHolderOfDTO holderOfDTO, IMediator mediator) : base(holderOfDTO)
        {
            _mediator = mediator;
        }



        [HttpGet("Owners")]
        public async Task<IActionResult> GetOwnersAsync()
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _mediator.Send(new GetOwnersLookUpQuery()));
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
