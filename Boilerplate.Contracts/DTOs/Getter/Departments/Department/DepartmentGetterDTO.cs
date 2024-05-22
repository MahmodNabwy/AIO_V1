using Boilerplate.Contracts.Bases;
using Boilerplate.Contracts.DTOs.Getter.Departments.DepartmentTranslation;
#nullable disable

namespace Boilerplate.Contracts.DTOs.Getter.Departments.Department
{
    public class DepartmentGetterDTO : BaseGetterUpdateDTO
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DepartmentGetterDTO MainDepartment { get; set; }
        public List<DepartmentTranslationGetterDTO> DepartmentTranslations { get; set; }
    }
}