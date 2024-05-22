using Boilerplate.API.Bases;
using Boilerplate.Contracts.Enums;
using Boilerplate.Contracts.Features.Languages.Commands;
using Boilerplate.Contracts.Features.Languages.Queries;
using Boilerplate.Contracts.Interfaces.Custom;
using Boilerplate.Infrastructure.Extentions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.API.Controllers.Admin.Languages
{
    [Route("api/admin/[controller]")]
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
        /// Get all  Languages in admin panal 
        /// </summary>
        /// <returns> All  Languages</returns>
        /// <remarks> Get all  Languages without filter For user that has get permission</remarks>
        [ActionPermissionWithModuleAndOperation((long)Modules.Languages, 1)]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _mediator.Send(new GetAllAdminLanguagesQuery()));
        }

        /// <summary>
        /// Get  Language in admin panal by Id
        /// </summary>
        /// <returns> Specific  Language </returns>
        /// <remarks> Get Specific  Language by id For user that has get permission</remarks>
        /// <param name="id" example="1">The  Language id</param>
        [ActionPermissionWithModuleAndOperation((long)Modules.Languages, 1)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _mediator.Send(new GetLanguageByIdAdminQuery() { Id = id }));
        }

        /// <summary>
        /// Add new Language in admin panal
        /// </summary>
        /// <remarks> 
        /// Add Language by user that has Add permisssions
        /// </remarks>
        [ActionPermissionWithModuleAndOperation((long)Modules.Languages, 2)]
        [HttpPost]
        public async Task<IActionResult> PostAsyncs([FromBody] CreateLanguageCommand command)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _mediator.Send(command));
        }

        /// <summary>
        /// Add new Language in admin panal
        /// </summary>
        /// <remarks> 
        /// Add Language by user that has Add permisssions
        /// </remarks>
        [ActionPermissionWithModuleAndOperation((long)Modules.Languages, 3)]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateLanguageCommand command)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _mediator.Send(command));
        }

        /// <summary>
        /// Delete  Language in admin panal
        /// </summary>
        /// <remarks> 
        /// Delete  Language by user that has Delete permisssions
        /// </remarks>
        /// <param name="id" example="1">The  Language id</param>
        [ActionPermissionWithModuleAndOperation((long)Modules.Languages, 5)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _mediator.Send(new DeleteLanguageCommand() { Id = id }));
        }

        /// <summary>
        /// Trashed  Language in admin panal
        /// </summary>
        /// <remarks> 
        /// Trashed  Language by user that has SoftDelete permisssions
        /// </remarks>
        /// <param name="id" example="1">The  Language id</param>
        [ActionPermissionWithModuleAndOperation((long)Modules.Languages, 4)]
        [HttpPut("Trash/{id}")]
        public async Task<IActionResult> Trash(long id)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _mediator.Send(new SoftDeleteLanguageCommand() { Id = id }));
        }

        /// <summary>
        /// UnTrashed Language in admin panal
        /// </summary>
        /// <remarks> 
        /// UnTrashed Language by user that has SoftDelete permisssions
        /// </remarks> 
        /// <param name="id" example="1">The  Language id</param>
        [ActionPermissionWithModuleAndOperation((long)Modules.Languages, 4)]
        [HttpPut("UnTrash/{id}")]
        public async Task<IActionResult> UnTrash(long id)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _mediator.Send(new CancelSoftDeleteLanguageCommand() { Id = id }));
        }
    }
}
