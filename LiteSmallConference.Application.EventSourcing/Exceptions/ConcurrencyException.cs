using LiteSmallConference.Domain.ValueObjects;

namespace LiteSmallConference.Application.EventSourcing.Exceptions
{
    public class ConcurrencyException : System.Exception
    {
        public ConcurrencyException(AggregateKey id)
            : base(string.Format("A different version than expected was found in aggregate {0}", id))
        {
        }
    }
}
