using Boilerplate.API.Bases;
using Boilerplate.Contracts.DTOs.Setter.Elements.Element;
using Boilerplate.Contracts.Filters;
using Boilerplate.Contracts.Interfaces.Custom;
using Boilerplate.Contracts.IServices.Services.Elements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.API.Controllers.Admin.Elements
{
    [Authorize]
    [Route("api/admin/[controller]")]
    [ApiController]
    public class ElementController : APIControllerBase
    {
        private readonly IElementService _ElementService;

        public ElementController(IHolderOfDTO holderOfDTO, IElementService ElementService) : base(holderOfDTO)
        {
            _ElementService = ElementService;
        }

        /// <summary>
        /// Get all  Elements in admin panal 
        /// </summary>
        /// <returns> All  Elements</returns>
        /// <remarks> Get all  Elements without filter For user that has get permission</remarks>

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] List<string> keys)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _ElementService.GetAllAdminAsync(keys));
        }

        /// <summary>
        /// Get all  Elements with filter in admin panal 
        /// </summary>
        /// <returns> All  Elements with filter</returns>
        /// <remarks> Get all  Elements with filter For user that has get permission</remarks>
        [HttpGet("Search")]
        public IActionResult Search([FromQuery] ElementFilter filter)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(_ElementService.SearchAdminAsync(filter));
        }

        /// <summary>
        /// Get  Element in admin panal by Id
        /// </summary>
        /// <returns> Specific  Element </returns>
        /// <remarks> Get Specific  Element by id For user that has get permission</remarks>
        /// <param name="id" example="1">The  Element id</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _ElementService.GetByIdAdminAsync(id));
        }
        /// <summary>
        /// Get  Element in admin panal by key
        /// </summary>
        /// <returns> Specific  Element </returns>
        /// <remarks> Get Specific  Element by key For user that has get permission</remarks>
        /// <param name="key" example="mission_vision">The  Element key</param>
        [HttpGet("GetByKey")]
        public async Task<IActionResult> GetAsync(string key)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _ElementService.GetByKeyAdminAsync(key));
        }

        /// <summary>
        /// Update  Element in admin panal
        /// </summary>
        /// <remarks> 
        /// Update  Element by user that has update permisssions
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ElementUpdateSetterDTO updateSetterDTO)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _ElementService.Update(updateSetterDTO));

        }

        /// <summary>
        /// Trashed  Element in admin panal
        /// </summary>
        /// <remarks> 
        /// Trashed  Element by user that has SoftDelete permisssions
        /// </remarks>
        [HttpPut("Trash/{id}")]
        public async Task<IActionResult> Trash(long id)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _ElementService.DeleteSoftAsync(id));
        }

        /// <summary>
        /// UnTrashed Element in admin panal
        /// </summary>
        /// <remarks> 
        /// UnTrashed Element by user that has SoftDelete permisssions
        /// </remarks>
        [HttpPut("UnTrash/{id}")]
        public async Task<IActionResult> UnTrash(long id)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _ElementService.CancelDeleteSoftAsync(id));
        }
    }
}
