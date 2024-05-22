using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace AIO.Core.Entities.Departments
{
    [Table("departments")]
    public partial class Department : BaseEntityUpdate
    {
        [Required(ErrorMessage = "Name is required")]
        [Column("name")]
        public string Name { get; set; }

        [Column("phone_number")]
        public string PhoneNumber { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("address")]
        public string Address { get; set; }

        [Column("parent_id")]
        public int? ParentId { get; set; } = null;

        [Column("is_active")]
        public bool IsActive { get; set; } = false;
        [ForeignKey(nameof(ParentId))]
        public virtual Department MainDepartment { get; set; }
        public virtual ICollection<DepartmentTranslation> DepartmentTranslations { get; set; }
        public virtual ICollection<DepartmentUser> DepartmentUsers { get; set; }

    }
}
