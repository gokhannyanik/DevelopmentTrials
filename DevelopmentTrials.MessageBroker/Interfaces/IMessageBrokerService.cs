using DevelopmentTrials.MessageBroker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopmentTrials.MessageBroker.Interfaces
{
    public interface IMessageBrokerService
    {
        void Send(RabbitMQMessageModel messageQ);
        void Listen(RabbitMQMessageModel messageQ);
    }
}
