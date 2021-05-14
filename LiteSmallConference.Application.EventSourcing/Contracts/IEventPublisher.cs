using LiteSmallConference.DomainEvents;

namespace LiteSmallConference.Application.EventSourcing.Contracts
{
    public interface IEventPublisher
    {
        void Publish<T>(T @event) where T : DomainEvent;
    }
}
