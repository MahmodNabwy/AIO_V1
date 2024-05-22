using AIO.Contracts.Bases;
using AIO.Contracts.Interfaces.Custom;
using MediatR;
#nullable disable

namespace AIO.Contracts.Features.Languages.Queries
{
    public class GetLanguageByIdAdminQuery : BaseGetterDTO, IRequest<IHolderOfDTO>
    {

    }
}
