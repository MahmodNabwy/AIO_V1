using Boilerplate.Shared.Helpers;

namespace Boilerplate.Contracts.IServices.Services.EmailSenderService
{
    public interface IEmailSenderService
    {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);
    }
}
