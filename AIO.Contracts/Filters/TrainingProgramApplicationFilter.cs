using AIO.Contracts.Enums;
using AIO.Contracts.Helpers;
#nullable disable
namespace AIO.Contracts.Filters
{
    public class TrainingProgramApplicationFilter :Pager
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Gender? Gender { get; set; }
        public long? TrainingProgramId { get; set; }
        public DateTime? ApplyingDate { get; set; }
        public DateTime? BirthDate { get; set; }

    }
}
