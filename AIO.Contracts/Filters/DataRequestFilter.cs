#nullable disable

using AIO.Contracts.Enums;

namespace AIO.Contracts.Filters
{
    public class DataRequestAdminFilter : AdminFilterBase
    {
        public string Employeer { get; set; }
        public string RequiredInformation { get; set; }
        public string UserId { get; set; }
        public PurposeOfRequestingData? PurposeOfRequestingData { get; set; }

        public FormOfDataRequested? FormOfDataRequested { get; set; }
    }
}
