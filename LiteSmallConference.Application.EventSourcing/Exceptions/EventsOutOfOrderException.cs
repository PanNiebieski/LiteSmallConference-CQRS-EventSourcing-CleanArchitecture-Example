using LiteSmallConference.Domain.ValueObjects;

namespace LiteSmallConference.Application.EventSourcing.Exceptions
{
    public class EventsOutOfOrderException : System.Exception
    {
        public EventsOutOfOrderException(AggregateKey id)
            : base(string.Format("Eventstore gave event for aggregate {0} out of order", id))
        {
        }
    }
}
