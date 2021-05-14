using LiteSmallConference.DomainEvents;
using LiteSmallConference.DomainEvents.Developers;
using LiteSmallConference.Infrastructure.EventStoreAndBus;
using System;

namespace GeekLemonConference.Infrastructure.EventStoreAndBus
{
    public static class DomainEventHelper
    {
        public static string WhatRabbitMQQueue(this DomainEvent @event)
        {
            string g = @event switch
            {
                DevloperSubmitedEvent => Constants.QUEUE_DEVELOPER_SUBMITED,
                DeveloperAcceptedEvent => Constants.QUEUE_DEVELOPER_ACCEPTED,
                DeveloperRejectedEvent => Constants.QUEUE_DEVELOPER_REJECTCED,
                _ => throw new NotImplementedException(),
            };

            return g;
        }
    }
}
