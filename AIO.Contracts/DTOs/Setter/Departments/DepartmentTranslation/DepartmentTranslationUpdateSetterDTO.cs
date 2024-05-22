using AIO.Contracts.Bases;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AIO.Contracts.DTOs.Setter.Departments.DepartmentTranslation
{
    public class DepartmentTranslationUpdateSetterDTO : BaseUpdateTranslationDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Address { get; set; }
    }
}