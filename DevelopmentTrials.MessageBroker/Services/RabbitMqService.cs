using DevelopmentTrials.MessageBroker.Interfaces;
using DevelopmentTrials.MessageBroker.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopmentTrials.MessageBroker.Services
{
    public class RabbitMqService : IMessageBrokerService
    {
        public void Listen(RabbitMQMessageModel messageQ)
        {
            var factory = new ConnectionFactory() { HostName = messageQ.HostName };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: messageQ.QueueID,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);






            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               messageQ.MessageReceived(ea);
            };
            channel.BasicConsume(queue: messageQ.QueueID,
                                 autoAck: true,
                                 consumer: consumer);
        }

        public void Send(RabbitMQMessageModel messageQ)
        {
            var factory = new ConnectionFactory() { HostName = messageQ.HostName };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: messageQ.QueueID,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);


                var body = Encoding.UTF8.GetBytes(messageQ.Message);

                channel.BasicPublish(exchange: "",
                                     routingKey: messageQ.QueueID,
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", messageQ.Message);
            }
        }
    }
}
