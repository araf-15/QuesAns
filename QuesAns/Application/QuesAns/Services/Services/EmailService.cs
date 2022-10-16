using QuesAns.Controllers;
using QuesAns.Models.AccountModels;
using QuesAns.Services.Contracts;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace QuesAns.Services.Services
{
    public class EmailService : IEmailService
    {
        private readonly SMTPConfigModel _smtpConfig;
        private readonly ILogger<AccountController> _logger;

        public EmailService(IOptions<SMTPConfigModel> smtpConfig, ILogger<AccountController> logger)
        {
            _smtpConfig = smtpConfig.Value;
            _logger = logger;
        }

        public async Task SendTestEmail(UserEmailOptionsModel userEmailOptions)
        {
            await SendEmail(userEmailOptions);
        }

        public async Task SendConfirmEmail(UserEmailOptionsModel userEmailOptions)
        {
            await SendEmail(userEmailOptions);
        }

        private async Task SendEmail(UserEmailOptionsModel userEmailOptions)
        {
            MailMessage mail = new MailMessage
            {
                Subject = userEmailOptions.Subject,
                Body = userEmailOptions.Body,
                From = new MailAddress(_smtpConfig.SenderAddress, _smtpConfig.SenderDisplayName),
                IsBodyHtml = _smtpConfig.IsBodyHtml
            };

            foreach (var toEmail in userEmailOptions.ToEmails)
            {
                mail.To.Add(toEmail);
            }

            NetworkCredential networkCredentials = new NetworkCredential(_smtpConfig.UserName, _smtpConfig.Password);

            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpConfig.Host,
                Port = _smtpConfig.Port,
                EnableSsl = _smtpConfig.EnableSSL,
                UseDefaultCredentials = _smtpConfig.UseDefaultCredentials,
                Credentials = networkCredentials
            };

            mail.BodyEncoding = Encoding.Default;

            await smtpClient.SendMailAsync(mail);
        }


        public void SendEmail(string sendAddress, string body, string fromAddress)
        {
            throw new NotImplementedException();
        }
    }
}
