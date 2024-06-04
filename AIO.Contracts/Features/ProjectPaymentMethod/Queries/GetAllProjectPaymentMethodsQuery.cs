using AIO.Contracts.Interfaces.Custom;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.Features.ProjectPaymentMethod.Queries
{
    public class GetAllProjectPaymentMethodsQuery : IRequest<IHolderOfDTO>
    {
        public int ProjectId { get; set; }
    }
}
