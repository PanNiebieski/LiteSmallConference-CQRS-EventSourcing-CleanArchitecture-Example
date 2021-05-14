using LiteSmallConference.Application.EventSourcing;
using LiteSmallConference.Application.EventSourcing.Contracts;
using LiteSmallConference.Application.EventSourcing.Exceptions;
using LiteSmallConference.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace GeekLemonConference.Infrastructure.EventStoreAndBus
{
    public class SessionForEventSourcing : ISessionForEventSourcing
    {
        private readonly IEventRepository _repository;
        private readonly Dictionary<AggregateKey, AggregateDescriptor> _trackedAggregates;

        public SessionForEventSourcing(IEventRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            _repository = repository;
            _trackedAggregates = new Dictionary<AggregateKey, AggregateDescriptor>();
        }

        public void Add<T>(T aggregate) where T : AggregateRoot
        {
            try
            {
                if (!IsTracked(aggregate.Key))
                    _trackedAggregates.Add(aggregate.Key,
                        new AggregateDescriptor
                        {
                            Aggregate = aggregate,
                            Version = aggregate.Version
                        });
                else if (_trackedAggregates[aggregate.Key].Aggregate != aggregate)
                    throw new ConcurrencyException(aggregate.Key);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public T Get<T>(AggregateKey id, int? expectedVersion = null) where T : AggregateRoot
        {
            try
            {
                //w pamięci sprawdzamy czy nie próbujemy ze złą wersją dodać zdarzenie
                if (IsTracked(id))
                {
                    var trackedAggregate = (T)_trackedAggregates[id].Aggregate;
                    if (expectedVersion != null && trackedAggregate.Version != expectedVersion)
                        throw new ConcurrencyException(trackedAggregate.Key);
                    return trackedAggregate;
                }

                //jeśli nie mamy w pamieci to odpytujemy repozytorium
                var aggregate = _repository.Get<T>(id);
                if (expectedVersion != null && aggregate.Version != expectedVersion)
                    throw new ConcurrencyException(id);
                Add(aggregate); //dodaj do tej warstwy pamięci

                return aggregate;
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        private bool IsTracked(AggregateKey id)
        {
            return _trackedAggregates.ContainsKey(id);
        }

        public void Commit()
        {
            try
            {
                foreach (var descriptor in _trackedAggregates.Values)
                {
                    _repository.Save(descriptor.Aggregate, descriptor.Version);
                }
                _trackedAggregates.Clear();
            }
            catch (Exception ex)
            {

                throw;

            }

        }

        private class AggregateDescriptor
        {
            public AggregateRoot Aggregate { get; set; }
            public int Version { get; set; }
        }
    }
}
