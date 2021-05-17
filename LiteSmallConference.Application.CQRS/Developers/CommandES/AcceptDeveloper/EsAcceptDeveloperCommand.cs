using MediatR;
using System;

namespace LiteSmallConference.Application.CQRS.Developers.CommandES.AcceptDeveloper
{
    public class EsAcceptDeveloperCommand
                     : IRequest<EsAcceptDeveloperCommandResponse>
    {
        public Guid DeveloperUniqueId { get; set; }
        public int Version { get; set; }
    }
}
