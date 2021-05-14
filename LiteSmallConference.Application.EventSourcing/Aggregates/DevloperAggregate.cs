using LiteSmallConference.Application.EventSourcing;
using LiteSmallConference.Domain.Entity;
using LiteSmallConference.Domain.ValueObject;
using LiteSmallConference.Domain.ValueObjects;
using LiteSmallConference.DomainEvents.Developers;

namespace GeekLemonConference.Application.EventSourcing.Aggregates
{
    public class DevloperAggregate : AggregateRoot
    {
        public DeveloperUniqueId UniqueId { get; set; }
        public string Name { get; set; }
        public DeveloperStatus Status { get; set; }

        private void Apply(DevloperSubmitedEvent e)
        {
            Status = DeveloperStatus.New;

            Name = e.Name;
            UniqueId = e.UniqueId;
            Version = e.Version++;
            this.Key = e.UniqueId.GetAggregateKey();
        }

        private void Apply(DeveloperAcceptedEvent e)
        {

            Status = e.Status;

            Name = e.Name;
            UniqueId = e.UniqueId;
            Version = e.Version++;
            this.Key = e.UniqueId.GetAggregateKey();
        }

        private void Apply(DeveloperRejectedEvent e)
        {
            Status = e.Status;

            Name = e.Name;
            UniqueId = e.UniqueId;
            Version = e.Version++;
            this.Key = e.UniqueId.GetAggregateKey();
        }





        public DevloperAggregate(DeveloperRejectedEvent cc)
        {
            var c = new DevloperSubmitedEvent
                (cc.UniqueId, cc.Name);
            this.Key = c.UniqueId.GetAggregateKey();
            ApplyChange(c);
        }

        public void Rejected(Developer cc)
        {
            var c = new DeveloperRejectedEvent
                (cc.UniqueId, cc.Name, cc.Status);
            this.Key = c.UniqueId.GetAggregateKey();
            ApplyChange(c);
        }



        public void Accepted(Developer cc)
        {
            var c = new DeveloperRejectedEvent
                           (cc.UniqueId, cc.Name, cc.Status);
            ApplyChange(c);
        }

        public DevloperAggregate()
        {

        }

    }
}
