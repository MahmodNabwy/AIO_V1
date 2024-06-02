using AIO.Contracts.Filters;
using AIO.Contracts.Interfaces.Custom;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.Features.Projects.Queries
{
    public class GetProjectsSearchQuery : ProjectFilter , IRequest<IHolderOfDTO>
    {
    }
}
