using MediatR;

namespace LiteSmallConference.Application.CQRS.Developers.Command.SubmitDeveloper
{
    public class SubmitDeveloperCommand : IRequest<SubmitDeveloperCommandResponse>
    {
        public string Name { get; set; }
    }
}
