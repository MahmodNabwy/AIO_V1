using AIO.Contracts.Bases;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AIO.Contracts.DTOs.Setter
{
    public class PermissionOperationSetterDTO : BaseUpdateSetterDTO
    {
        [Display(Name = "name")]
        public string Name { get; set; }
    }
}