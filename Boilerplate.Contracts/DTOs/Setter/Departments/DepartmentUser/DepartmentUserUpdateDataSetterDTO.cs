using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Boilerplate.Contracts.DTOs.Setter.Departments.DepartmentUser
{
    public class DepartmentUserUpdateDataSetterDTO
    {
        [Required(ErrorMessage = "DepartmentId is required")]
        public long DepartmentId { get; set; }
    }
}