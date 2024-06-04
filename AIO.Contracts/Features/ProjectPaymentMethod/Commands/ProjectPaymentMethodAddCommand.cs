using AIO.Contracts.Interfaces.Custom;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.Features.ProjectPaymentMethod.Commands
{
    public class ProjectPaymentMethodAddCommand : IRequest<IHolderOfDTO>
    {
        public int ProjectId { get; set; }
        public int Percentage { get; set; }
        public decimal Amount { get; set; }
        public int currency { get; set; }
        public int TypeId { get; set; }
        public DateTime Date { get; set; }
    }
}
