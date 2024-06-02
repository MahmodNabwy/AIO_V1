using AIO.API.Bases;
using AIO.Contracts.Features.Projects.Commands;
using AIO.Contracts.Features.SuppliersProjectsItems.Commands;
using AIO.Contracts.Helpers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIO.API.Controllers.Admin.SupplierProjectItem
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class SupplierProjectItemController : APIControllerBase
    {
        private readonly IMediator _mediator;

        public SupplierProjectItemController(HolderOfDTO holderOfDTO, IMediator mediator) : base(holderOfDTO)
        {
            _mediator = mediator;

        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SupplierProjectItemsAddCommand request)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();


            return State(await _mediator.Send(request));
        }
    }
}
