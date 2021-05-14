using MediatR;
using System;

namespace LiteSmallConference.Application.CQRS.Developers.Command.RejectDeveloper
{
    public class RejectDeveloperCommand
        : IRequest<RejectDeveloperCommandResponse>
    {
        public Guid DeveloperUniqueId { get; set; }
    }
}
