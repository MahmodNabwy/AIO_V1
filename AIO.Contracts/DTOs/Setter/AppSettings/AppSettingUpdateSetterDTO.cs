using AIO.Contracts.Bases;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace AIO.Contracts.DTOs.Setter.AppSettings;
public class AppSettingUpdateSetterDTO : BaseSetterDTO
{
    [Required]
    public string Key { get; set; }
    [Required]
    public string Value { get; set; }
}
