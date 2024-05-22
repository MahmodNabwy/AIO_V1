using AutoMapper;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.IServices.Services.EmailSenderService;
using AIO.Core.Bases;
using AIO.Core.IServices.Custom;
using AIO.Shared.Consts;
using AIO.Shared.Helpers;
using AIO.Shared.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MimeKit;
using Newtonsoft.Json;

namespace AIO.Application.Services.EmailSenderService
{
    public class EmailSenderService : BaseService<EmailSenderService>, IEmailSenderService
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailSenderService(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture, IHostEnvironment environment,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor, ILogger<EmailSenderService> logger)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)

        {
            var config = _unitOfWork.AppSettings.FirstOrDefaultAsync(q => q.Key == AppSettingKeys.EmailConfiguration).Result;
            if (config != null)
                _emailConfig = JsonConvert.DeserializeObject<EmailConfiguration>(config.Value);
            else
                _emailConfig = null;
        }

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);

            Send(emailMessage);
        }

        public async Task SendEmailAsync(Message message)
        {
            var mailMessage = CreateEmailMessage(message);

            await SendAsync(mailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();

            if (_emailConfig != null)
            {
                emailMessage.From.Add(new MailboxAddress(name: _emailConfig.From, address: _emailConfig.From));
                emailMessage.To.AddRange(message.To);
                emailMessage.Subject = message.Subject;

                var bodyBuilder = new BodyBuilder { HtmlBody = message.Content };

                if (message.Attachments != null && message.Attachments.Any())
                {
                    byte[] fileBytes;
                    foreach (var attachment in message.Attachments)
                    {
                        using (var ms = new MemoryStream())
                        {
                            attachment.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
                    }
                }
                emailMessage.Body = bodyBuilder.ToMessageBody();
            }
            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.CheckCertificateRevocation = false;
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, SecureSocketOptions.Auto);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
                    client.Send(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception, or both.
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private async Task SendAsync(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.CheckCertificateRevocation = false;
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, SecureSocketOptions.Auto);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);
                    await client.SendAsync(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception, or both.
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
    }
}
