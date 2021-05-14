using LiteSmallConference.Domain.ValueObjects;

namespace LiteSmallConference.Application.EventSourcing.Contracts
{
    //public interface ISessionForEventSourcing
    //{
    //    void Add<T>(T aggregate) where T : AggregateRoot;
    //    T Get<T>(AggregateKey id, int? expectedVersion = null) where T : AggregateRoot;
    //    void Commit();
    //}

    public interface ISessionForEventSourcing
    {
        void Add<T>(T aggregate) where T : AggregateRoot;
        T Get<T>(AggregateKey id, int? expectedVersion = null) where T : AggregateRoot;
        void Commit();
    }
}
