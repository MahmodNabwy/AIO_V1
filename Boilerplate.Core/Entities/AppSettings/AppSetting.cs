using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace Boilerplate.Core.Entities.AppSettings
{
    [Index(nameof(Key), Name = "key_unique", IsUnique = true)]
    [Table("app_settings")]
    public class AppSetting : BaseEntityWithUpdate
    {
        [Column("key")]
        public string Key { get; set; }
        [Column("value")]
        public string Value { get; set; }
        [Column("is_system")]
        public bool IsSystem { get; set; } = false;
    }
}
