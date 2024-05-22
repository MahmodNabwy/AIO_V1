using System.ComponentModel.DataAnnotations;
#nullable disable

namespace AIO.Contracts.DTOs.Setter.Departments.DepartmentUser
{
    public class DepartmentBatchSetterDTO
    {
        [Required(ErrorMessage = "DepartmentId is required")]
        public int DepartmentId { get; set; }
        public bool IsManager { get; set; } = false;
    }
}