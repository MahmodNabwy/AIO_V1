using AIO.Shared.Helpers;

namespace AIO.Contracts.IServices.Custom
{
    public interface IJobs
    {
        public Task SendEmailEmergency(Message message);
        public Task SendEmailNormaly(Message message);
    }
}
