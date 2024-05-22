using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Boilerplate.Contracts.DTOs.Setter.AppSettings;

public class AppSettingSetterDTO
{
    [Required]
    public string Key { get; set; }
    [Required]
    public string Value { get; set; }

}