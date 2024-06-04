using AIO.Contracts.Interfaces.Custom;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.Features.Items.Commands
{
    public class ItemsAddCommand :IRequest<IHolderOfDTO>
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
