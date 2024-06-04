using AIO.Contracts.Interfaces.Custom;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.Features.ProjectInsurances.Commands
{
    public class ProjectInsuranceDeleteCommand : IRequest<IHolderOfDTO>
    {
        public int Id { get; set; }
    }
}
