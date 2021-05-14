using LiteSmallConference.Domain.ValueObjects;
using LiteSmallConference.DomainEvents;
using System.Collections.Generic;

namespace LiteSmallConference.Application.EventSourcing.Contracts
{
    public interface IEventStore
    {
        void Save(DomainEvent @event);
        List<DomainEvent> Get(AggregateKey aggregateId, int fromVersion);
    }
}
