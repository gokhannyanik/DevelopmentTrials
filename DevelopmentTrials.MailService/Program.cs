using DevelopmentTrials.MessageBroker.Interfaces;
using DevelopmentTrials.MessageBroker.Models;
using DevelopmentTrials.MessageBroker.Services;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;

namespace DevelopmentTrials.MailService
{
    class Program
    {

        static void Main(string[] args)
        {

            ServiceProvider serviceProvider = new ServiceCollection()
                                         .AddScoped<IMessageBrokerService, RabbitMqService>()
                                         .BuildServiceProvider();
            var messageBrokerService = serviceProvider.GetService<IMessageBrokerService>();
            messageBrokerService.Listen(new RabbitMQMessageModel()
            {
                HostName = "localhost",
                QueueID = "mail-queue",
                MessageReceived = MessageReceived
            });
            
            Thread.Sleep(Timeout.Infinite);

        }

        private static void MessageReceived(BasicDeliverEventArgs obj)
        {
            var body = obj.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            SendMail(message);
        }

        private static void SendMail(string email)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("ekrem.deger15@gmail.com");
            message.To.Add(new MailAddress(email));
            message.Subject = "EKREM DEGER E";
            message.IsBodyHtml = true; //to make message body as html  
            message.Body = "At kafası ekrem";
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new NetworkCredential("ekrem.deger15@gmail.com", "5034802bjK");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }
    }
}
