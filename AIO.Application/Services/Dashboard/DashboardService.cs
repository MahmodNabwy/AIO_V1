using AutoMapper;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.IServices.Services.Dashboard;
using AIO.Core.Bases;
using AIO.Core.IServices.Custom;
using AIO.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AIO.Application.Services.Dashboard
{
    public class DashboardService : BaseService<DashboardService>, IDashboardServices
    {

        public DashboardService(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
           IHostEnvironment environment, IHttpContextAccessor httpContextAccessor, ILogger<DashboardService> logger)
           : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
        }

    }
}
