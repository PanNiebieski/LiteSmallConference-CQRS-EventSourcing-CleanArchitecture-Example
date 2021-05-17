using LiteSmallConference.Domain.ValueObject;
using LiteSmallConference.Domain.ValueObjects;

namespace LiteSmallConference.DomainEvents.Developers
{
    public class DeveloperRejectedEvent : DomainEvent
    {
        public DeveloperUniqueId UniqueId { get; set; }
        public string Name { get; set; }
        public DeveloperStatus Status { get; set; }

        public DeveloperRejectedEvent(DeveloperUniqueId uniqueId,
    string name, DeveloperStatus status, int version)
        {
            UniqueId = uniqueId;
            Status = status;
            Name = name;
            Version = version;
            Key = uniqueId.GetAggregateKey();
        }
    }
}
