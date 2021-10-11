using Investeer.DataAccess.Repository.IRepository;
using Investeer.Models.Models;
using Investeer.Utility;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static Investeer.Models.MyEnum;

namespace Investeer.DataAccess.Repository
{
    public class EmailService : IEmailService
    {
        EmailSettings _mailSettings = null;
        public EmailService(IOptions<EmailSettings> options)
        {
            _mailSettings = options.Value;
        }

        public async Task SendEmailAsync<T, S, U>(Email mailRequest, T t, S s, U u)
        {
            try
            {
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
                email.Sender.Name = _mailSettings.DisplayName;
                if (mailRequest.ToAdmin)
                    email.To.Add(MailboxAddress.Parse(_mailSettings.AdminMailId));
                else
                {
                    foreach (var to in mailRequest.ToEmails)
                    {
                        email.To.Add(MailboxAddress.Parse(to));
                    }
                }

                var builder = new BodyBuilder();
                if (mailRequest.Attachments != null)
                {
                    byte[] fileBytes;
                    foreach (var file in mailRequest.Attachments)
                    {
                        if (file.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                file.CopyTo(ms);
                                fileBytes = ms.ToArray();
                            }
                            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                        }
                    }
                }
                if (!string.IsNullOrEmpty(((EmailTemplates)mailRequest.TemplateName).GetEnumMemberValue()))
                {
                    string _path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Templates", ((EmailTemplates)mailRequest.TemplateName).GetEnumMemberValue());
                    if (File.Exists(_path)) mailRequest.Body = _path.ReadFile().PrepareTemplate<T, S, U>(t, s, u);
                    _path = _path.Substring(0, _path.LastIndexOf('.')) + ".Subject.txt";
                    if (File.Exists(_path)) mailRequest.Subject = _path.ReadFile().PrepareTemplate<T, S, U>(t, s, u);
                }
                email.Subject = mailRequest.Subject;
                builder.HtmlBody = mailRequest.Body;
                email.Body = builder.ToMessageBody();
                using (var smtp = new SmtpClient())
                {
                    smtp.CheckCertificateRevocation = false;
                    smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.Auto);
                    //smtp.AuthenticationMechanisms.Remove("XOAUTH2");
                    smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                    await smtp.SendAsync(email);
                    smtp.Disconnect(true);
                }

            }
            catch
            {
                throw;
            }

        }
    }

}
