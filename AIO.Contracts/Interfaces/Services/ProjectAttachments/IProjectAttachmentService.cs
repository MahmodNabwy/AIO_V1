using AIO.Contracts.DTOs.Setter.Files;
using AIO.Contracts.DTOs.Setter.ProjectPaymentMethod;
using AIO.Contracts.Interfaces.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.Interfaces.Services.ProjectAttachments
{
    public interface IProjectAttachmentService
    {

        Task<IHolderOfDTO> AddNewProjectAttachments(int projectId, List<UploadAttachmentSetterDTO> setterDTO);

    }
}
