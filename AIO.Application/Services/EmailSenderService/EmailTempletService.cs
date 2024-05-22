using AutoMapper;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.IServices.Services.EmailSenderService;
using AIO.Contracts.IServices.Services.PasswordGeneration;
using AIO.Core.Bases;
using AIO.Core.IServices.Custom;
using AIO.Shared.Helpers;
using AIO.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AIO.Application.Services.EmailSenderService;

public class EmailTempletService : BaseService<EmailTempletService>, IEmailTempleteService
{
    private readonly IEmailSenderService _emailSender;
    public EmailTempletService(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture, IHostEnvironment environment,
        IPasswordGenerationService passwordGeneration, IEmailSenderService emailSender, IHttpContextAccessor httpContextAccessor, ILogger<EmailTempletService> logger)
        : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
    {
        _emailSender = emailSender;
    }
    public async Task SendEmailOfCompleteMigration(string title, List<string> to)
    {
        try
        {
            if (to.Count() > 0)
            {
                var messageContent = string.Format(_unitOfWork.AppSettings.Find(q => q.Key == "complete_migration_email").Value, title);
                var message = new Message(to, "تم رفع النشره", messageContent, null);
                _emailSender.SendEmail(message);
            }
        }
        catch (Exception ex)
        {

        }
    }
    public async Task SendEmailOfUnCompleteMigration(string title, string sheet, int row, int col, List<string> to)
    {
        try
        {
            if (to.Count() > 0)
            {
                var messageContent = string.Format(_unitOfWork.AppSettings.Find(q => q.Key == "uncomplete_migration_email").Value, title, sheet, row, col);
                var message = new Message(to, "حدث خطأ اثناء رفع النشره", messageContent, null);
                _emailSender.SendEmail(message);
            }
        }
        catch (Exception ex)
        {

        }
    }

    public async Task SendUserPasswordMail(string name, string userName, string password, string email, string url = "")
    {
        var messageContent = GetEmailTemplate(name, userName, password, url = "");
        var message = new Message(new string[] { email }, "Boilerplate Account Details", messageContent, null);
        _emailSender.SendEmailAsync(message);

    }
    private string GetEmailTemplate(string name, string username, string password, string url = "")
    {
        var message =
            @"<!DOCTYPE html PUBLIC ' -//W3C//DTD HTML 4.0 Transitional//EN' 'http://www.w3.org/TR/REC-html40/loose.dtd'>
        <html lang='en' xmlns='http://www.w3.org/1999/xhtml' xmlns:v='urn:schemas-microsoft-com:vml'
            xmlns:o='urn:schemas-microsoft-com:office:office'
            style='height: 100% !important; width: 100% !important; font-family: ' Roboto', sans-serif !important; font-size:
            14px; line-height: 24px; font-weight: 400; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0
            auto; padding: 0;'>

        <head>
            <meta http-equiv='Content-Type' content='text/html; charset=utf-8'>
            <meta charset='utf-8'>
            <meta name='viewport' content='width=device-width'>
            <meta http-equiv='X-UA-Compatible' content='IE=edge'>
            <meta name='x-apple-disable-message-reformatting'>
            <title></title>
            <style>
                @font-face {
                    font-family: 'Roboto';
                    font-style: normal;
                    font-weight: 400;
                    src: url('https://fonts.gstatic.com/s/roboto/v30/KFOmCnqEu92Fr1Mu4mxP.ttf') format('truetype');
                }

                body {
                    margin: 0 auto !important;
                    padding: 0 !important;
                    height: 100% !important;
                    width: 100% !important;
                    font-family: 'Roboto', sans-serif !important;
                    font-size: 14px;
                    margin-bottom: 10px;
                    line-height: 24px;
                    font-weight: 400;
                }

                img {
                    -ms-interpolation-mode: bicubic;
                }
            </style>
        </head>

        <body width='100%' style='mso-line-height-rule: exactly; height: 100% !important; width: 100% !important; font-family: '
            Roboto', sans-serif !important; font-size: 14px; line-height: 24px; font-weight: 400; -ms-text-size-adjust: 100%;
            -webkit-text-size-adjust: 100%; margin: 0 auto; padding: 0;' bgcolor='#f5f6fa'>
            <center
                style='width: 100%; background-color: #f5f6fa; text-align: right; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'>
                <table width='100%' border='0' cellpadding='0' cellspacing='0' bgcolor='#f5f6fa'
                    style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; mso-table-lspace: 0pt !important; mso-table-rspace: 0pt !important; border-spacing: 0 !important; border-collapse: collapse !important; table-layout: fixed !important; margin: 0 auto; padding: 0;'>
                    <tbody style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'>
                        <tr style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'>
                            <td
                                style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; mso-table-lspace: 0pt !important; mso-table-rspace: 0pt !important; margin: 0; padding: 40px 0;'>
                                <table
                                    style='width: 100%; max-width: 620px; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; mso-table-lspace: 0pt !important; mso-table-rspace: 0pt !important; border-spacing: 0 !important; border-collapse: collapse !important; table-layout: fixed !important; margin: 0 auto; padding: 0;'>
                                    <tbody
                                        style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'>
                                        <tr
                                            style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'>
                                            <td style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; mso-table-lspace: 0pt !important; mso-table-rspace: 0pt !important; margin: 0; padding: 0 0 25px;'
                                                align='center'><a
                                                    href='#e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855'
                                                    style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; text-decoration: none; margin: 0; padding: 0;'><img
                                                        style='height: 40px; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; -ms-interpolation-mode: bicubic; margin: 0; padding: 0;'
                                                        src='https://admin.digitalhub.com.eg/static/media/logo-dark.235b0ea8.svg'
                                                        alt='logo'></a>
                                                <p
                                                    style='font-size: 14px; color: #000000; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 12px 0 0;'>
                                                    A Complete Digital Learning and Continual Improvement Platform</p>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <table
                                    style='width: 100%; max-width: 620px; text-align: right; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; mso-table-lspace: 0pt !important; mso-table-rspace: 0pt !important; border-spacing: 0 !important; border-collapse: collapse !important; table-layout: fixed !important; margin: 0 auto; padding: 0;'
                                    bgcolor='#ffffff'>
                                    <tbody
                                        style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'>
                                        <tr
                                            style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'>
                                            <td
                                                style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; mso-table-lspace: 0pt !important; mso-table-rspace: 0pt !important; margin: 0; padding: 30px 30px 15px;'>
                                                <p
                                                    style='direction: rtl; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0 0 10px; padding: 0;'>
                                                    مرحبا،" + name + @" </p><br>
                                                <p
                                                    style='direction: rtl; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0 0 0px; padding: 0;'>
                                                        يسعدنا أن نخبركم أنه تم إنشاء حساب جديد</p>
                                                        <br>                                               
                                                        <p
                                                        style='direction: rtl; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0 0 0px; padding: 0;'>
                                                            اسم المستخدم " + username + @"</p><br>
                                                            <p
                                                            style='direction: rtl; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0 0 0px; padding: 0;'>
                                                                كلمه السر " + password + @"</p>
                                                            <br>
                                                        <a href='" + url + @"'
                                                    style='background-color: #3e79f7; border-radius: 4px; color: #ffffff; display: inline-block; font-size: 15px; font-weight: 600; line-height: 44px; text-align: center; text-decoration: none; text-transform: uppercase; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0 30px;'>الدخول
                                                    الى المنصة</a>
                                            </td>                                  
                                        </tr>                
                                        <tr
                                            style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'>
                                            <td
                                                style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; mso-table-lspace: 0pt !important; mso-table-rspace: 0pt !important; margin: 0; padding: 20px 30px 40px;'>
                                                <p
                                                    style='font-size: 13px; line-height: 22px; color: #9ea8bb; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'>
                                                    هذا بريد إلكتروني تم إنشاؤه تلقائيًا ، يرجى عدم الرد على هذا البريد
                                                    الإلكتروني. إذا واجهت أي مشاكل ، فيرجى الاتصال بنا على help@AIO.app</p>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <table
                                    style='width: 100%; max-width: 620px; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; mso-table-lspace: 0pt !important; mso-table-rspace: 0pt !important; border-spacing: 0 !important; border-collapse: collapse !important; table-layout: fixed !important; margin: 0 auto; padding: 0;'>
                                    <tbody
                                        style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'>
                                        <tr
                                            style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'>
                                            <td style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; mso-table-lspace: 0pt !important; mso-table-rspace: 0pt !important; margin: 0; padding: 25px 20px 0;'
                                                align='center'>
                                                <p
                                                    style='font-size: 13px; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'>
                                                    Copyright © 2023 AIO.app. All rights reserved. </p>
                                                <p
                                                    style='font-size: 13px; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 15px 0 0; padding: 0;'>
                                                    Powered by <a
                                                        style='color: #3e79f7; text-decoration: none; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'
                                                        href='https://digitalhub.com.eg'>Digital Hub</a>.</p>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </center>
        </body>

        </html>";
        return message;
    }
}