using System.ComponentModel.DataAnnotations;
#nullable disable

namespace AIO.Contracts.DTOs.Setter
{
    public class PermissionModuleSetterDTO
    {
        [Display(Name = "name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}