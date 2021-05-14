
using LiteSmallConference.DomainEvents;
using System;

namespace GeekLemonConference.Application.EventSourcing.Contracts
{
    public interface IBusEventHandler
    {
        Type HandlerType { get; }
        void Handle(DomainEvent @event);
    }
}
