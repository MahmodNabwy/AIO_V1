using AIO.Contracts.Bases;
using AIO.Contracts.Interfaces.Custom;
using MediatR;
#nullable disable

namespace AIO.Contracts.Features.Languages.Commands
{
    public class SoftDeleteLanguageCommand : BaseSetterDTO, IRequest<IHolderOfDTO>
    {
    }
}
