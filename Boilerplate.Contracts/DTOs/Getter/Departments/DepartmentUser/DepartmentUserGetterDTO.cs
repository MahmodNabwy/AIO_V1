using Boilerplate.Contracts.Bases;
#nullable disable

namespace Boilerplate.Contracts.DTOs.Getter.Departments.DepartmentUser
{
    public class DepartmentUserGetterDTO : BaseGetterUpdateDTO
    {
        public string UserId { get; set; }
        public long DepartmentId { get; set; }
        public bool IsManager { get; set; } = false;
        public string UserName { get; set; }
        public string DepartmentName { get; set; }
    }
}