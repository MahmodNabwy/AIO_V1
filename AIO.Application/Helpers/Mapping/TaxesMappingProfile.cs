using AIO.Contracts.DTOs.Getter.Lookups;
using AIO.Core.Entities.Owners;
using AIO.Core.Entities.Taxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Application.Helpers
{
    public partial class MappingProfile
    {
        private void TaxesMappingProfile()
        {
            CreateMap<Tax, LookupGetterDTO>().ReverseMap();
        }
    }
}
