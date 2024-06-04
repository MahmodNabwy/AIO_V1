using AIO.Contracts.Interfaces.Custom;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.Features.ProjectTaxes.Commands
{
    public class ProjectTaxesUpdateCommand : IRequest<IHolderOfDTO>
    {
        public int ProjectId { get; set; }
        public List<int> TaxesIds { get; set; }
    }
}
