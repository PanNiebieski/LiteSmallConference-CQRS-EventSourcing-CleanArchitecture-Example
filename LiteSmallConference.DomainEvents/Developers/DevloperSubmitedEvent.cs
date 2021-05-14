using LiteSmallConference.Domain.ValueObjects;

namespace LiteSmallConference.DomainEvents.Developers
{
    public class DevloperSubmitedEvent : DomainEvent
    {
        public DeveloperUniqueId UniqueId { get; set; }
        public string Name { get; set; }
        //public DeveloperStatus Status { get; set; }

        public DevloperSubmitedEvent(DeveloperUniqueId uniqueId,
            string name)
        {
            UniqueId = uniqueId;
            Name = name;
        }
    }
}
