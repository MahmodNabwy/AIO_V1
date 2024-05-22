using AIO.Core.Entities.Auth;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace AIO.Core.Entities.Departments
{
    [Table("department_users")]
    public partial class DepartmentUser : BaseEntityUpdate
    {
        [Column("user_id")]
        public string UserId { get; set; }
        [Column("department_id")]
        public int DepartmentId { get; set; }
        [Column("is_manager")]
        public bool IsManager { get; set; } = false;

        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}
