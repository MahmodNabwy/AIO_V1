using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.DTOs.Setter.ProjectAttachments
{
    public class ProjectAttachmentsSetterDTO
    {
        public int ProjectId { get; set; }

        public string Uid { get; set; }
        public string Url { get; set; }

        public string Size { get; set; }

        public int MediaType { get; set; }
    }
}
