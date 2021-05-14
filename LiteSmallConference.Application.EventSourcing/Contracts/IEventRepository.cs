using LiteSmallConference.Domain.ValueObjects;

namespace LiteSmallConference.Application.EventSourcing.Contracts
{
    public interface IEventRepository
    {
        void Save<T>(T aggregate, int? expectedVersion = null) where T : AggregateRoot;
        T Get<T>(AggregateKey aggregateId) where T : AggregateRoot;
    }

    //public interface IEventRepository
    //{
    //    ExecutionStatus Save<T>(T aggregate, int? expectedVersion = null) where T : AggregateRoot;
    //    ExecutionStatus<T> Get<T>(AggregateKey aggregateId) where T : AggregateRoot;
    //}
}
