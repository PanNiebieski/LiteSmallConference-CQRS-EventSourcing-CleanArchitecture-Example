using MediatR;
using System;

namespace LiteSmallConference.Application.CQRS.Developers.Command.AcceptDeveloper
{
    public class AcceptDeveloperCommand
               : IRequest<AcceptDeveloperCommandResponse>
    {
        public Guid DeveloperUniqueId { get; set; }
    }
}
