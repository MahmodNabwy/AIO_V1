using AIO.Shared.Helpers;

namespace AIO.Contracts.IServices.Services.EmailSenderService
{
    public interface IEmailSenderService
    {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);
    }
}
