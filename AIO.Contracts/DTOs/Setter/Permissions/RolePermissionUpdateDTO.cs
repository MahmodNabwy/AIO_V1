using System.ComponentModel.DataAnnotations;
#nullable disable

namespace AIO.Contracts.DTOs.Setter
{
    public class RolePermissionUpdateDTO
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "module_id")]
        public int ModuleId { get; set; }

        [Required]
        [Display(Name = "operation_id")]
        public int OperationId { get; set; }
    }
}