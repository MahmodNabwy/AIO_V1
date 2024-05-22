using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AIO.Contracts.DTOs.Setter.Departments.Department
{
    public class DepartmentSetterDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public long? ParentId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Translation is required")]
        public virtual List<DepartmentTranslationSetterDTO> DepartmentTranslations { get; set; }
    }
}