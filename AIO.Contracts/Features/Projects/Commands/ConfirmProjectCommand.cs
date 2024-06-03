using AIO.Contracts.Interfaces.Custom;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.Features.Projects.Commands
{
    public class ConfirmProjectCommand : IRequest<IHolderOfDTO>
    {
        public int ProjectId { get; set; }
    }
}
