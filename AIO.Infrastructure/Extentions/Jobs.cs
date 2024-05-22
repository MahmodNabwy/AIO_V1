using AIO.Contracts.IServices.Custom;
using AIO.Contracts.IServices.Services.EmailSenderService;
using AIO.Shared.Helpers;
using Hangfire;

namespace AIO.Infrastructure.Extentions
{
    public class Jobs : IJobs
    {
        private readonly IEmailSenderService _emailSender;
        public Jobs(IEmailSenderService emailSender)
        {
            _emailSender = emailSender;
        }
        [Queue("a")]
        public Task SendEmailEmergency(Message message)
        {
            BackgroundJob.Enqueue<IEmailSenderService>(x => x.SendEmailAsync(message));
            return Task.CompletedTask;
        }
        public Task SendEmailNormaly(Message message)
        {
            BackgroundJob.Enqueue<Message>(x => _emailSender.SendEmailAsync(x));
            return Task.CompletedTask;
        }
    }
}