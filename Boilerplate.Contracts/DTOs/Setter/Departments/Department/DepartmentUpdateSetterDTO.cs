using Boilerplate.Contracts.Bases;
using Boilerplate.Contracts.DTOs.Setter.Departments.DepartmentTranslation;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Boilerplate.Contracts.DTOs.Setter.Departments.Department
{
    public class DepartmentUpdateSetterDTO : BaseSetterDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public long? ParentId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Translation is required")]
        public List<DepartmentTranslationUpdateSetterDTO> DepartmentTranslations { get; set; }
    }
}