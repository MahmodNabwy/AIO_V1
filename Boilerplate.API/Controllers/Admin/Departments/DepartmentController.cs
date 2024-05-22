using Boilerplate.API.Bases;
using Boilerplate.Contracts.DTOs.Setter.Departments.Department;
using Boilerplate.Contracts.Enums;
using Boilerplate.Contracts.Filters;
using Boilerplate.Contracts.Interfaces.Custom;
using Boilerplate.Contracts.IServices.Services.Departments;
using Boilerplate.Infrastructure.Extentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.API.Controllers.Admin.Departments
{
    [Route("api/admin/[controller]")]
    [Authorize]
    [ApiController]
    public class DepartmentController : APIControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IHolderOfDTO holderOfDTO, IDepartmentService departmentService) : base(holderOfDTO)
        {
            _departmentService = departmentService;
        }

        /// <summary>
        /// Get all  Departments in admin panal 
        /// </summary>
        /// <returns> All  Departments</returns>
        /// <remarks> Get all  Departments without filter For user that has get permission</remarks>
        [ActionPermissionWithModuleAndOperation((long)Modules.Departments, 1)]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _departmentService.GetAllAdminAsync());
        }

        /// <summary>
        /// Get all Departments with filter in admin panal 
        /// </summary>
        /// <returns> All Departments with filter</returns>
        /// <remarks> Get all Departments with filter For user that has get permission</remarks>
        [ActionPermissionWithModuleAndOperation((long)Modules.Departments, 1)]
        [HttpGet("Search")]
        public IActionResult Search([FromQuery] DepartmentAdminFilter filter)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(_departmentService.SearchAdminAsync(filter));
        }

        /// <summary>
        /// Get  Department in admin panal by Id
        /// </summary>
        /// <returns> Specific  Department </returns>
        /// <remarks> Get Specific  Department by id For user that has get permission</remarks>
        /// <param name="id" example="1">The  Department id</param>
        [ActionPermissionWithModuleAndOperation((long)Modules.Departments, 1)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _departmentService.GetByIdAdminAsync(id));
        }

        /// <summary>
        /// Add new Department in admin panal
        /// </summary>
        /// <remarks> 
        /// Add Department by user that has Add permisssions
        /// </remarks>
        [UpdateActionPermissionWithModuleAndOperation((long)Modules.Departments, 2)]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] DepartmentSetterDTO GroupSetterDTO)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _departmentService.SaveAsync(GroupSetterDTO));
        }

        /// <summary>
        /// Update  Department in admin panal
        /// </summary>
        /// <remarks> 
        /// Update  Department by user that has update permisssions
        /// </remarks>
        [UpdateActionPermissionWithModuleAndOperation((long)Modules.Departments, 3)]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DepartmentUpdateSetterDTO GroupSetterDTO)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _departmentService.Update(GroupSetterDTO));
        }

        /// <summary>
        /// Delete  Department in admin panal
        /// </summary>
        /// <remarks> 
        /// Delete  Department by user that has Delete permisssions
        /// </remarks>
        /// <param name="id" example="1">The  Department id</param>
        [ActionPermissionWithModuleAndOperation((long)Modules.Departments, 5)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _departmentService.Delete(id));
        }

        /// <summary>
        /// Trashed  Department in admin panal
        /// </summary>
        /// <remarks> 
        /// Trashed  Department by user that has SoftDelete permisssions
        /// </remarks>
        /// <param name="id" example="1">The  Department id</param>
        [ActionPermissionWithModuleAndOperation((long)Modules.Departments, 4)]
        [HttpPut("Trash/{id}")]
        public async Task<IActionResult> Trash(long id)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _departmentService.DeleteSoftAsync(id));
        }

        /// <summary>
        /// UnTrashed Department in admin panal
        /// </summary>
        /// <remarks> 
        /// UnTrashed Department by user that has SoftDelete permisssions
        /// </remarks> 
        /// <param name="id" example="1">The  Department id</param>
        [ActionPermissionWithModuleAndOperation((long)Modules.Departments, 4)]
        [HttpPut("UnTrash/{id}")]
        public async Task<IActionResult> UnTrash(long id)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();
            return State(await _departmentService.CancelDeleteSoftAsync(id));
        }
    }
}
