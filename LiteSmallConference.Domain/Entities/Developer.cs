using LiteSmallConference.Domain.Ddd;
using LiteSmallConference.Domain.ValueObject;
using LiteSmallConference.Domain.ValueObjects;
using LiteSmallConference.Domain.ValueObjects.Identities;

namespace LiteSmallConference.Domain.Entity
{
    public class Developer : Entity<DeveloperId, DeveloperUniqueId>
    {
        public string Name { get; set; }
        public DeveloperStatus Status { get; set; }


        public DeveloperIds Ids()
        {
            if (this.Id != null && this.Id.Value != default)
                return new DeveloperIds()
                {
                    UniqueId = this.UniqueId,
                    CreatedId = this.Id
                };
            else
                return new DeveloperIds()
                {
                    UniqueId = this.UniqueId,
                    CreatedId = this.Id,
                    ExStatus = IdsStatus.DudeYouCantReturnCreatedIdWhenYouAreEventSourcing

                };
        }
    }
}
