using LiteSmallConference.DomainEvents;

namespace GeekLemonConference.Application.EventSourcing.Messages
{
    public interface IHandler<T> where T : DomainEvent
    {
        void Handle(T message);
    }
}
