﻿using HrManagement.Application.Contracts.Infrastructure.Abstraction;
using HrManagement.Application.DTOs.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Net;
using System.Threading.Tasks;

namespace HrManagement.Infrastructure.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSetting _emailSetting;
        public EmailSender(IOptions<EmailSetting> emailSerrings)
        {
            _emailSetting = emailSerrings.Value;
        }

        public async Task<bool> SendEmail(EmailDTO email)
        {
            var client = new SendGridClient(_emailSetting.ApiKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress { 
                Email = _emailSetting.FromAddress,
                Name = _emailSetting.FromName
            };
            var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            var response = await client.SendEmailAsync(message);

            return 
                response.StatusCode == HttpStatusCode.OK || 
                response.StatusCode == HttpStatusCode.Accepted; //more option
        }
    }
}
