using AIO.Contracts.Bases;
using AIO.Contracts.DTOs.Getter.Departments.DepartmentTranslation;
#nullable disable

namespace AIO.Contracts.DTOs.Getter.Departments.Department
{
    public class DepartmentDataGetterDTO : BaseGetterDTO
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public long BoilerplateSectorId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public virtual DepartmentDataGetterDTO MainDepartment { get; set; }
        public List<DepartmentTranslationDataGetterDTO> DepartmentTranslations { get; set; }
    }
}