using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.DTOs.Getter.Projects
{
    public record ProjectDateGetterByIdDTO
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string OwnerName { get; init; }
        public string ContractNumber { get; init; }
        public string PoNumber { get; init; }
        public string AssignedNumber { get; init; }
        public DateTime AssignedToDate { get; init; }
        public DateTime PrimaryRecieptDate { get; init; }
        public DateTime FinalRecieptDate { get; init; }
        public decimal TotalPrice { get; init; }
        public int TotalPriceConcurrency { get; init; }
        public decimal LimitOfLiability { get; init; }
        public int? ProjectProfitabilityRatio { get; init; }
        public int ImplementationPeriod { get; init; }
        public int InsurancePeriod { get; init; }
        public string PaymentCondition { get; init; }
        public bool IsNew { get; init; }
        public int? ParentId { get; init; }
        public int ProjectTypeId { get; init; }
        public int OwnerId { get; init; }
        public bool? HasDiscount { get; init; } = false;
        public decimal? TotalPriceAfterDiscount { get; init; }

        public List<ProjectInsurancesDataGetterDTO> Insurances { get; set; }
        public List<ProjectTaxesGetterDTO> Taxes { get; set; }

        public List<ProjectPaymentMethodGetterDTO> PaymentMethods { get; set; }
    }
}
