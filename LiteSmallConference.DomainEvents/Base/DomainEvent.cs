
using LiteSmallConference.Domain;
using LiteSmallConference.Domain.ValueObjects;
using System;

namespace LiteSmallConference.DomainEvents
{
    public abstract class DomainEvent
    {
        public AggregateKey Key { get; set; }

        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }

        protected DomainEvent(DateTimeOffset occuredOn, int version)
        {
            TimeStamp = occuredOn;
            Version = version;
        }

        protected DomainEvent(int version)
        {
            TimeStamp = AppTime.Now();
            Version = version;
        }

        protected DomainEvent()
        {

        }

    }
}
