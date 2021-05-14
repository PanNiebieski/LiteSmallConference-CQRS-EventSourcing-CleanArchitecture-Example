using LiteSmallConference.Application.EventSourcing.Contracts;
using LiteSmallConference.Domain.ValueObjects;
using LiteSmallConference.DomainEvents;
using System.Collections.Generic;
using System.Linq;

namespace LiteSmallConference.Infrastructure.EventStoreAndBus.Repositories.EventStore
{
    public class InMemoryEventStore : IEventStore
    {
        private readonly Dictionary<AggregateKey, List<DomainEvent>> customerInMemDictionary = new Dictionary<AggregateKey, List<DomainEvent>>();

        public List<DomainEvent> Get(AggregateKey aggregateId, int fromVersion)
        {
            List<DomainEvent> geekLemonEvents;
            customerInMemDictionary.TryGetValue(aggregateId, out geekLemonEvents);
            if (geekLemonEvents != null)
            {
                return geekLemonEvents.Where(x => x.Version > fromVersion).ToList();
            }

            return new List<DomainEvent>();
        }

        public void Save(DomainEvent @event)
        {
            List<DomainEvent> geekLemonEvents;
            customerInMemDictionary.TryGetValue(@event.Key, out geekLemonEvents);
            if (geekLemonEvents == null)
            {
                geekLemonEvents = new List<DomainEvent>();
                customerInMemDictionary.Add(@event.Key, geekLemonEvents);
            }
            geekLemonEvents.Add(@event);
        }
    }
}
