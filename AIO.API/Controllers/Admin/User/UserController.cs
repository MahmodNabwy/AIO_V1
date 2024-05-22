using AIO.API.Bases;
using AIO.Contracts.DTOs.Auth.Setter;
using AIO.Contracts.Enums;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.IServices.Services.Auth;
using AIO.Infrastructure.Extentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AIO.API.Controllers.Admin.User;
[Authorize]
[Route("api/admin/[controller]")]
public class UserController : APIControllerBase
{
    private readonly IUserService _userService;

    public UserController(IHolderOfDTO holderOfDTO, IUserService userService) : base(holderOfDTO)
    {
        _userService = userService;
    }

    /// <summary>
    /// Add new employee in admin panal
    /// </summary>
    /// <remarks> 
    /// Add employee by user that has Add permisssions
    /// </remarks>
    [ActionPermissionWithModuleAndOperation((long)Modules.Users, 2)]
    [HttpPost("AddUser")]
    public async Task<IActionResult> AddUserAsync([FromBody] UserSetterDTO setterDTO)
    {
        if (!ModelState.IsValid)
            return NotValidModelState();
        return State(await _userService.AddNewEmployeeAsync(setterDTO));
    }
}