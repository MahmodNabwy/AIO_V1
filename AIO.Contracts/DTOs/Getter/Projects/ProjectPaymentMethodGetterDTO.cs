using AIO.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.DTOs.Getter.Projects
{
    public record ProjectPaymentMethodGetterDTO
    {
        public int Id { get; set; }
        public int Percentage { get; set; }
        public decimal Amount { get; set; }
        public int currency { get; set; }
        public int TypeId { get; set; }
        public DateTime Date { get; set; }

    }
}
