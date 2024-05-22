using Boilerplate.Shared.Helpers;

namespace Boilerplate.Contracts.IServices.Custom
{
    public interface IJobs
    {
        public Task SendEmailEmergency(Message message);
        public Task SendEmailNormaly(Message message);
    }
}
