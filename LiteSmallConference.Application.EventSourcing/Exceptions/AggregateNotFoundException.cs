using LiteSmallConference.Domain.ValueObjects;

namespace LiteSmallConference.Application.EventSourcing.Exceptions
{
    public class AggregateNotFoundException : System.Exception
    {
        public AggregateNotFoundException(AggregateKey id)
            : base(string.Format("Aggregate {0} was not found", id))
        {
        }
    }
}
