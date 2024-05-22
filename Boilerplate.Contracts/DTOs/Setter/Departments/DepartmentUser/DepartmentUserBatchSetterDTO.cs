using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Boilerplate.Contracts.DTOs.Setter.Departments.DepartmentUser
{
    public class DepartmentUserBatchSetterDTO
    {
        [Required(ErrorMessage = "UserId is required")]
        public string UserId { get; set; }
        public List<DepartmentBatchSetterDTO> Departments { get; set; }
    }
}