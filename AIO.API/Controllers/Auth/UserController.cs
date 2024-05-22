using AIO.API.Bases;
using AIO.Contracts.DTOs.Auth.Setter;
using AIO.Contracts.DTOs.Setter.Files;
using AIO.Contracts.Enums;
using AIO.Contracts.Filters.Auth;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.IServices.Services.Auth;
using AIO.Infrastructure.Extentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AIO.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : APIControllerBase
    {
        private readonly IUserService _userService;
        private DataHub hub = new DataHub();

        public UserController(IHolderOfDTO holderOfDTO, IUserService userService) : base(holderOfDTO)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get all  users in admin panal 
        /// </summary>
        /// <returns> All  users</returns>
        /// <remarks> Get all  users without filter For user that has get permission</remarks>
        [ActionPermissionWithModuleAndOperation((long)Modules.Users, 1)]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            if (!ModelState.IsValid)
                return NotValidModelState();

            return State(await _userService.GetAllAsync());
        }

        /// <summary>
        /// Get all AdminUser in admin panal 
        /// </summary>
        /// <returns> All AdminUser</returns>
        /// <remarks> Get all AdminUser without filter For user that has get permission</remarks>
        [ActionPermissionWithModuleAndOperation((long)Modules.Users, 1)]
        [HttpGet("AdminUser")]
        public async Task<IActionResult> GetAllAdminUserAsync()
        {
            if (!ModelState.IsValid)
                return NotValidModelState();

            return State(await _userService.GetAllAdminUsersAsync());
        }

        /// <summary>
        /// Get all End-users in admin panal 
        /// </summary>
        /// <returns> All End-users</returns>
        /// <remarks> Get all End-users without filter for user that has get permission</remarks>
        [ActionPermissionWithModuleAndOperation((long)Modules.Users, 1)]
        [HttpGet("EndUser")]
        public async Task<IActionResult> GetAllEndUserAsync()
        {
            if (!ModelState.IsValid)
                return NotValidModelState();

            return State(await _userService.GetAllEndUsersAsync());
        }
        /// <summary>
        /// Search users in admin panal 
        /// </summary>
        /// <returns> Search  users</returns>
        /// <remarks> filter users by user that has get permission</remarks>
        [ActionPermissionWithModuleAndOperation((long)Modules.Users, 1)]
        [HttpGet("Search")]
        public async Task<IActionResult> SearchAsync([FromQuery] UserFilter filter)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _userService.SearchAsync(filter));
        }

        //[ActionPermissionWithModuleAndOperation((long)Modules.Users, 1)]
        //[HttpGet("/api/admin/GetOnlineEmployee")]
        //public async Task<IActionResult> GetOnlineEmployee()
        //{
        //    if (!ModelState.IsValid)
        //        return NotValidModelState();
        //    return State(await _userService.GetOnlineUsers(hub.GetOnlineEmployeeIds()));
        //}

        /// <summary>
        /// Get  user in admin panal by Id
        /// </summary>
        /// <returns> Specific  user </returns>
        /// <remarks> Get Specific user by id for user that has get permission</remarks>
        /// <param name="id" example="c1be5862-d402-4a31-8fs9-6aded859f7a8">The  user id</param>
        [ActionPermissionWithModuleAndOperation((long)Modules.Users, 1)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _userService.GetByIdAsync(id));
        }


        /// <summary>
        /// Update system user in admin panal
        /// </summary>
        /// <remarks> 
        /// Update  system user by user that has update permisssions
        /// </remarks>
        [ActionPermissionWithModuleAndOperation((long)Modules.Users, 3)]
        [HttpPut]
        public async Task<IActionResult> Put(UserUpdateSetterDTO userDTO)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _userService.UpdateAsync(userDTO));
        }

        /// <summary>
        /// upload user image
        /// </summary>
        /// <remarks> 
        /// upload user image by user in admin panal or site
        /// </remarks>
        [HttpPost("UploadUserImage")]
        public async Task<IActionResult> UploadUserImageAsync([FromForm] FileSetterDTO fileSetterDTO)
        {
            if (!ModelState.IsValid)
            {
                return NotValidModelState();
            }
            return State(await _userService.ProfilePictureAsync(fileSetterDTO));
        }


        /// <summary>
        /// Delete  user in admin panal
        /// </summary>
        /// <remarks> 
        /// Delete  user by user that has Delete permisssions
        /// </remarks>
        [ActionPermissionWithModuleAndOperation((long)Modules.Users, 5)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (!ModelState.IsValid)
            {
                return NotValidModelState();
            }
            return State(await _userService.Delete(id));
        }

        /// <summary>
        /// Add new user in admin panal
        /// </summary>
        /// <remarks> 
        /// Add user system by user that has Add permisssions
        /// </remarks>
        //[ActionPermissionWithModuleAndOperation((long)Modules.Users, 2)]
        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody] UserSetterDTO setterDTO)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _userService.AddNewEmployeeAsync(setterDTO));
        }

        /// <summary>
        /// Ban user in admin panal
        /// </summary>
        /// <remarks> 
        /// Ban user by user that has soft delete permisssions in admin panal
        /// </remarks>
        [ActionPermissionWithModuleAndOperation((long)Modules.Users, 4)]
        [HttpPost("BanUser")]
        public async Task<IActionResult> BanUser(string id)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();

            return State(await _userService.BanUser(id));
        }

        /// <summary>
        /// Active user in admin panal
        /// </summary>
        /// <remarks> 
        /// Active user by user that has soft delete permisssions in admin panal
        /// </remarks>
        [ActionPermissionWithModuleAndOperation((long)Modules.Users, 4)]
        [HttpPost("ActiveUser")]
        public async Task<IActionResult> ActiveUser(string id)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();

            return State(await _userService.ActiveUser(id));
        }

        /// <summary>
        /// UnlockedUser user in admin panal
        /// </summary>
        /// <remarks> 
        /// UnlockedUser user by user that has update permission in admin panal
        /// </remarks>
        [Authorize]
        [ActionPermissionWithModuleAndOperation((long)Modules.Users, 4)]
        [HttpPost("UnlockedUser")]
        public async Task<IActionResult> UnlockedUser(string id)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();

            return State(await _userService.UnlockedUser(id));
        }
    }
}
