using AIO.Contracts.Bases;

#nullable disable

namespace AIO.Contracts.DTOs.Getter.Departments.DepartmentTranslation
{
    public class DepartmentTranslationGetterDTO : BaseGetterUpdateTranslationDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }

    }
}