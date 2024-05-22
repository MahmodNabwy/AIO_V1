using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Boilerplate.Contracts.DTOs.Setter.Departments.DepartmentUser
{
    public class DepartmentBatchSetterDTO
    {
        [Required(ErrorMessage = "DepartmentId is required")]
        public long DepartmentId { get; set; }
        public bool IsManager { get; set; } = false;
    }
}