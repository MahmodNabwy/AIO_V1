using AIO.Contracts.Bases;
#nullable disable

namespace AIO.Contracts.DTOs.Getter.Departments.DepartmentTranslation
{
    public class DepartmentTranslationDataGetterDTO : BaseGetterTranslationDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}