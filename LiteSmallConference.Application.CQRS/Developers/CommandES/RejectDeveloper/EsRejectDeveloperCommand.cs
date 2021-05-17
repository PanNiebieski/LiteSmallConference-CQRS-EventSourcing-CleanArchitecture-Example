using MediatR;
using System;

namespace LiteSmallConference.Application.CQRS.Developers.CommandES.RejectDeveloper
{
    public class EsRejectDeveloperCommand
        : IRequest<EsRejectDeveloperCommandResponse>
    {
        public Guid DeveloperUniqueId { get; set; }
        public int Version { get; set; }
    }
}
