using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AIO.Contracts.DTOs.Setter
{
    public class RolePermissionSetterDTO
    {
        public int Id { get; set; }
        [Display(Name = "role_id")]
        public string RoleId { get; set; }
        [Display(Name = "module_id")]
        public int ModuleId { get; set; }
        [Display(Name = "operation_id")]
        public int OperationId { get; set; }
    }
}