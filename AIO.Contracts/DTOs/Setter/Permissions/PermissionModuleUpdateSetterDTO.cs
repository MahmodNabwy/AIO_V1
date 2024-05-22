using System.ComponentModel.DataAnnotations;
#nullable disable

namespace AIO.Contracts.DTOs.Setter
{
    public class PermissionModuleUpdateSetterDTO
    {
        public long Id { get; set; }
        [Display(Name = "name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}