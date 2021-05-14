namespace LiteSmallConference.Domain.ValueObjects.Identities
{


    public class DeveloperIds
    {
        public DeveloperId CreatedId { get; set; }
        public DeveloperUniqueId UniqueId { get; set; }

        public IdsStatus Status { get; set; }
    }

    public enum IdsStatus
    {
        CreateIdReturned = 0,
        DudeYouCantReturnCreatedIdWhenYouAreEventSourcing = 1
    }
}
