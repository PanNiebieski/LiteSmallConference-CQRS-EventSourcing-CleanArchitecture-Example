
using GeekLemonConference.Application.EventSourcing.Messages;
using LiteSmallConference.DomainEvents;

namespace GeekLemonConference.Application.EventSourcing.Contracts
{
    public interface IEventHandler<T> : IHandler<T> where T : DomainEvent
    {
    }
}
