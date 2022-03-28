using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Html;

namespace Blog.Components.Services
{
    //kitmat is used hire
    public class EmailMessageService
    {
        public static async Task SendEmailMessageAsync(string subject,string userEmail,string message)
        {
            var emailmessage = new MimeMessage();
            emailmessage.From.Add(new MailboxAddress("Администрация сайта", "ozabello21@gmail.com"));
            emailmessage.To.Add(new MailboxAddress("",userEmail));
            emailmessage.Subject = subject;
            emailmessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client =new SmtpClient())
            {   
                await client.ConnectAsync("smtp.gmail.com",465, true);
                await client.AuthenticateAsync("ozabello21@gmail.com", "ehuabafznitgjeff");
                await client.SendAsync(emailmessage);

                await client.DisconnectAsync(true);
                
            }

        }
    }
}
