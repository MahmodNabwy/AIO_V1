using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.DTOs.Getter.Items
{
    public record ItemGetterDTO
    {
        public int Id { get; init; }
        public string Code { get; init; }
        public string Description { get; init; }
    }
}
