using AIO.Contracts.Enums;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.IServices.Services.AppSettings;
using AIO.Infrastructure.Extentions;
using AIO.API.Bases;

using Microsoft.AspNetCore.Mvc;
using AIO.Contracts.DTOs.Setter.AppSettings;

namespace AIO.API.Controllers.Admin.Agency
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class AppSettingController : APIControllerBase
    {
        private readonly IAppSettingService _AppSettingService;

        public AppSettingController(IHolderOfDTO holderOfDTO, IAppSettingService AppSettingService) : base(holderOfDTO)
        {
            _AppSettingService = AppSettingService;
        }

        [HttpGet]
        [ActionPermissionWithModuleAndOperation((long)Modules.Settings, 1)]
        public async Task<IActionResult> GetAllAsync()
        {
            if (!ModelState.IsValid)
                return NotValidModelState();

            var result = await _AppSettingService.GetAllAsync();

            return State(result);

        }

        [HttpPost]
        [ActionPermissionWithModuleAndOperation((long)Modules.Settings, 2)]
        public async Task<IActionResult> SaveAsync([FromBody] AppSettingSetterDTO setterDTO)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();

            return State(await _AppSettingService.SaveAsync(setterDTO));
        }

        [HttpPut]
        [ActionPermissionWithModuleAndOperation((long)Modules.Settings, 3)]
        public async Task<IActionResult> UpdateAsync([FromBody] AppSettingUpdateSetterDTO updateDTO)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();

            return State(await _AppSettingService.UpdateAsync(updateDTO));
        }
    }
}
