using AIO.API.Bases;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.IServices.Services.Elements;
using Microsoft.AspNetCore.Mvc;

namespace AIO.API.Controllers.EndUser.Elements
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ElementController : APIControllerBase
    {
        private readonly IElementService _ElementService;

        public ElementController(IHolderOfDTO holderOfDTO, IElementService ElementService) : base(holderOfDTO)
        {
            _ElementService = ElementService;
        }

        /// <summary>
        /// Get all Elements to end user in site 
        /// </summary>
        /// <returns> All Element</returns>
        /// <remarks> Get published and untrashed Element For end user in site</remarks>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] List<string> keys)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _ElementService.GetAllAsync(keys));
        }

        /// <summary>
        /// Get Element by key to end user in site 
        /// </summary>
        /// <returns> Get Element by key</returns>
        /// <remarks> Get published and untrashed Element by key for end user in site</remarks>
        [HttpGet("GetByKey")]
        public async Task<IActionResult> GetByKeyAsync(string key)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _ElementService.GetByKeyAsync(key));
        }
    }
}
