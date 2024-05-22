using Boilerplate.Contracts.Bases;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Boilerplate.Contracts.DTOs.Setter.Departments.DepartmentUser
{
    public class DepartmentUserUpdateSetterDTO : BaseDeleteSetterDTO
    {
        [Required(ErrorMessage = "UserId is required")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "DepartmentId is required")]
        public long DepartmentId { get; set; }
        public bool IsManager { get; set; } = false;
    }
}