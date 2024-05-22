using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace AIO.Core.Entities.Departments
{
    [Table("department_translations")]
    public class DepartmentTranslation : BaseEntityTranslation
    {
        [Required(ErrorMessage = "Name is required")]
        [Column("name")]
        public string Name { get; set; }
        [Column("address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Department Id is required")]
        [Column("department_id")]
        public int DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }
    }
}
