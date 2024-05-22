using Boilerplate.API.Bases;
using Boilerplate.Contracts.DTOs.Setter.Departments.DepartmentUser;
using Boilerplate.Contracts.Enums;
using Boilerplate.Contracts.Interfaces.Custom;
using Boilerplate.Contracts.IServices.Services.Departments;
using Boilerplate.Infrastructure.Extentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.API.Controllers.Admin.DepartmentUsers
{
    [Route("api/admin/[controller]")]
    [Authorize]
    [ApiController]
    public class DepartmentUserController : APIControllerBase
    {
        private readonly IDepartmentUserService _departmentUserService;

        public DepartmentUserController(IHolderOfDTO holderOfDTO, IDepartmentUserService departmentUserService) : base(holderOfDTO)
        {
            _departmentUserService = departmentUserService;
        }

        /// <summary>
        /// Get all  Department Users in admin panal 
        /// </summary>
        /// <returns> All  Department Users</returns>
        /// <remarks> Get all  Department Users without filter For user that has get permission</remarks>
        [ActionPermissionWithModuleAndOperation((long)Modules.DepartmentUsers, 1)]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _departmentUserService.GetAllAdminAsync());
        }

        /// <summary>
        /// Get  Department User in admin panal by Id
        /// </summary>
        /// <returns> Specific  Department User </returns>
        /// <remarks> Get Specific  Department User by id For user that has get permission</remarks>
        /// <param name="id" example="1">The  Department User id</param>
        [ActionPermissionWithModuleAndOperation((long)Modules.DepartmentUsers, 1)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _departmentUserService.GetByIdAdminAsync(id));
        }

        /// <summary>
        /// Add new Department User in admin panal
        /// </summary>
        /// <remarks> 
        /// Add Department User by user that has Add permisssions
        /// </remarks>
        [UpdateActionPermissionWithModuleAndOperation((long)Modules.DepartmentUsers, 2)]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] DepartmentUserSetterDTO setterDTO)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _departmentUserService.SaveAsync(setterDTO));
        }
        /// <summary>
        /// Assign User to list of Departments in admin panal
        /// </summary>
        /// <remarks> 
        /// Assign User to list of Departmentsby user that has Add permisssions
        /// </remarks>
        [UpdateActionPermissionWithModuleAndOperation((long)Modules.DepartmentUsers, 2)]
        [HttpPost("SaveBatch")]
        public async Task<IActionResult> PostBatchAsync([FromBody] DepartmentUserBatchSetterDTO setterDTO)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _departmentUserService.SaveBatchAsync(setterDTO));
        }

        /// <summary>
        /// Update  Department User in admin panal
        /// </summary>
        /// <remarks> 
        /// Update  Department User by user that has update permisssions
        /// </remarks>
        [UpdateActionPermissionWithModuleAndOperation((long)Modules.DepartmentUsers, 3)]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DepartmentUserUpdateSetterDTO updateDTO)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _departmentUserService.Update(updateDTO));
        }

        /// <summary>
        /// Delete  Department User in admin panal
        /// </summary>
        /// <remarks> 
        /// Delete  Department User by user that has Delete permisssions
        /// </remarks>
        /// <param name="id" example="1">The  Department User id</param>
        [ActionPermissionWithModuleAndOperation((long)Modules.DepartmentUsers, 5)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _departmentUserService.Delete(id));
        }

        /// <summary>
        /// Trashed  Department User in admin panal
        /// </summary>
        /// <remarks> 
        /// Trashed  Department User by user that has SoftDelete permisssions
        /// </remarks>
        /// <param name="id" example="1">The  Department User id</param>
        [ActionPermissionWithModuleAndOperation((long)Modules.DepartmentUsers, 4)]
        [HttpPut("Trash/{id}")]
        public async Task<IActionResult> Trash(long id)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _departmentUserService.DeleteSoftAsync(id));
        }

        /// <summary>
        /// UnTrashed Department User in admin panal
        /// </summary>
        /// <remarks> 
        /// UnTrashed Department User by user that has SoftDelete permisssions
        /// </remarks> 
        /// <param name="id" example="1">The  Department User id</param>
        [ActionPermissionWithModuleAndOperation((long)Modules.DepartmentUsers, 4)]
        [HttpPut("UnTrash/{id}")]
        public async Task<IActionResult> UnTrash(long id)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _departmentUserService.CancelDeleteSoftAsync(id));
        }
    }
}
