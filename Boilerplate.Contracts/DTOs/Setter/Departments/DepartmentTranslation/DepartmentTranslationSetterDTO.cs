using Boilerplate.Contracts.Bases;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Boilerplate.Contracts.DTOs.Setter
{
    public class DepartmentTranslationSetterDTO : BaseSetterTranslationDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Address { get; set; }
    }
}