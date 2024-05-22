using AIO.Contracts.Interfaces.Custom;

namespace AIO.Contracts.Helpers
{
    public class HolderOfDTO : Dictionary<string, object>, IHolderOfDTO
    {
        public HolderOfDTO()
        {
        }
    }
}
