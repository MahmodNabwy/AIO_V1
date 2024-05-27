using AIO.Contracts.DTOs.Setter.Files;
using AIO.Contracts.Helpers;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.Interfaces.Services.ProjectAttachments;
using AIO.Core.Bases;
using AIO.Core.Entities.ProjectAttachments;
using AIO.Core.IServices.Custom;
using AIO.Shared.Consts;
using AIO.Shared.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Application.Services.ProjectAttachments
{
    public class ProjectAttachmentService : BaseService<ProjectAttachmentService>, IProjectAttachmentService
    {
        public ProjectAttachmentService(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<ProjectAttachmentService> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {

        }

        public async Task<IHolderOfDTO> AddNewProjectAttachments(int projectId, List<UploadAttachmentSetterDTO> setterDTO)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var projectsAttachmentsList = _mapper.Map<IList<ProjectsAttachments>>(setterDTO);
                var oProjectAttachments = await _unitOfWork.ProjectAttachment.AddRangeAsync(projectsAttachmentsList);
                _unitOfWork.Complete();


                lIndicators.Add(_unitOfWork.Complete() > 0);
                _logger.LogInformation(Res.message, Res.Added);

            }
            catch (Exception ex)
            {
                ExceptionError(lIndicators, ex.Message);

            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;


        }
    }
}
