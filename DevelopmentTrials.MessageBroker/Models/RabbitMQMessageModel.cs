using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopmentTrials.MessageBroker.Models
{
    public class RabbitMQMessageModel
    {
        public string HostName { get; set; }
        public string QueueID { get; set; }
        public string Message { get; set; }
        public Action<BasicDeliverEventArgs> MessageReceived { get; set; }
    }
}
