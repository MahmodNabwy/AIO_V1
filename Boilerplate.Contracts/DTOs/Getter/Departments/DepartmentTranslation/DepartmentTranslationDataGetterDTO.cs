using Boilerplate.Contracts.Bases;
#nullable disable

namespace Boilerplate.Contracts.DTOs.Getter.Departments.DepartmentTranslation
{
    public class DepartmentTranslationDataGetterDTO : BaseGetterTranslationDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}