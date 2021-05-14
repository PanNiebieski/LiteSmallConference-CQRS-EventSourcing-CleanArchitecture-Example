using LiteSmallConference.Domain.ValueObject;
using LiteSmallConference.Domain.ValueObjects;

namespace LiteSmallConference.DomainEvents.Developers
{
    public class DeveloperAcceptedEvent : DomainEvent
    {
        public DeveloperUniqueId UniqueId { get; set; }
        public string Name { get; set; }
        public DeveloperStatus Status { get; set; }


        public DeveloperAcceptedEvent(DeveloperUniqueId uniqueId,
            string name, DeveloperStatus status)
        {
            UniqueId = uniqueId;
            Status = status;
            Name = name;
        }
    }

}
