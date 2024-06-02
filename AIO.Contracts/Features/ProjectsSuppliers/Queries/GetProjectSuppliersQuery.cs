using AIO.Contracts.Filters;
using AIO.Contracts.Helpers;
using AIO.Contracts.Interfaces.Custom;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.Features.ProjectsSuppliers.Queries
{
    public class GetProjectSuppliersQuery : Pager, IRequest<IHolderOfDTO>
    {
        public int ProjectId { get; set; }
        public int TypeId { get; set; } 
    }
}
