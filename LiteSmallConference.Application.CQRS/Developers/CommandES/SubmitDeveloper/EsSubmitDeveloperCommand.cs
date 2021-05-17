using LiteSmallConference.Domain.ValueObject;
using LiteSmallConference.Domain.ValueObjects;
using MediatR;
using System.Text.Json.Serialization;

namespace LiteSmallConference.Application.CQRS.Developers.CommandES.SubmitDeveloper
{
    public class EsSubmitDeveloperCommand
            : IRequest<EsSubmitDeveloperCommandResponse>
    {
        public string Name { get; set; }

        [JsonIgnore]
        public int Version { get; }
        [JsonIgnore]
        public DeveloperUniqueId UniqueId { get; }
        [JsonIgnore]
        public DeveloperStatus Status { get; }

        public EsSubmitDeveloperCommand()
        {
            Version = 0;
            UniqueId = new DeveloperUniqueId();
            Status = DeveloperStatus.New;
        }
    }
}
