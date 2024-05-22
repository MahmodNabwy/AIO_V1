#nullable disable

using System.ComponentModel.DataAnnotations;

namespace AIO.Contracts.DTOs.Setter.Departments.DepartmentUser
{
    public class DepartmentUserSetterDTO
    {
        [Required(ErrorMessage = "UserId is required")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "DepartmentId is required")]
        public long DepartmentId { get; set; }
        public bool IsManager { get; set; } = false;
    }
}