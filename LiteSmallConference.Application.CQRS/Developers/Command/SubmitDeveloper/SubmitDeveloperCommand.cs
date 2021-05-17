using LiteSmallConference.Domain.ValueObject;
using LiteSmallConference.Domain.ValueObjects;
using MediatR;
using System.Text.Json.Serialization;

namespace LiteSmallConference.Application.CQRS.Developers.Command.SubmitDeveloper
{
    public class SubmitDeveloperCommand : IRequest<SubmitDeveloperCommandResponse>
    {
        public string Name { get; set; }

        [JsonIgnore]
        public DeveloperUniqueId UniqueId { get; }
        [JsonIgnore]
        public DeveloperStatus Status { get; }

        public SubmitDeveloperCommand()
        {
            UniqueId = new DeveloperUniqueId();
            Status = DeveloperStatus.New;
        }
    }
}
