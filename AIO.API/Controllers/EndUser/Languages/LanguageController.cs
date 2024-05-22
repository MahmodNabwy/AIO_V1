using AIO.API.Bases;
using AIO.Contracts.Features.Languages.Queries;
using AIO.Contracts.Interfaces.Custom;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AIO.API.Controllers.EndUser.Languages
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class LanguageController : APIControllerBase
    {
        private readonly IMediator _mediator;
        public LanguageController(IHolderOfDTO holderOfDTO, IMediator mediator) : base(holderOfDTO)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all languages to end user in site 
        /// </summary>
        /// <returns> All languages</returns>
        /// <remarks> Get published and untrashed languages For end user in site</remarks>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync()
        {
            if (!ModelState.IsValid)
                return NotValidModelState();

            return State(await _mediator.Send(new GetAllLanguagesQuery()));
        }

    }
}
