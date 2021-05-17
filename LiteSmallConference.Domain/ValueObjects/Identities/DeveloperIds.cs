using System.Text.Json.Serialization;

namespace LiteSmallConference.Domain.ValueObjects.Identities
{


    public class DeveloperIds
    {
        public DeveloperId CreatedId { get; set; }
        public DeveloperUniqueId UniqueId { get; set; }

        [JsonIgnore]
        public IdsStatus ExStatus { get; set; }

        public string Status
        {
            get
            {
                return ExStatus.ToString();
            }
        }
    }

    public enum IdsStatus
    {
        CreateIdReturned = 0,
        DudeYouCantReturnCreatedIdWhenYouAreEventSourcing = 1
    }
}
