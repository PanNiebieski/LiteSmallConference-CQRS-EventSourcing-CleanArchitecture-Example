using LiteSmallConference.Domain.Ddd;
using LiteSmallConference.Domain.ValueObject;
using LiteSmallConference.Domain.ValueObjects;

namespace LiteSmallConference.Domain.Entity
{
    public class Developer : Entity<DeveloperId, DeveloperUniqueId>
    {
        public string Name { get; set; }
        public DeveloperStatus Status { get; set; }
    }
}
