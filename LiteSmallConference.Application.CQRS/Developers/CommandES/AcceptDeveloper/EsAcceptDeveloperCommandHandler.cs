using AutoMapper;
using GeekLemonConference.Application.EventSourcing.Aggregates;
using LiteSmallConference.Application.EventSourcing.Contracts;
using LiteSmallConference.Domain.Entity;
using LiteSmallConference.Domain.ValueObject;
using LiteSmallConference.Domain.ValueObjects;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LiteSmallConference.Application.CQRS.Developers.CommandES.AcceptDeveloper
{
    public class EsAcceptDeveloperCommandHandler
        :
        IRequestHandler<EsAcceptDeveloperCommand, EsAcceptDeveloperCommandResponse>
    {
        private readonly ISessionForEventSourcing _sessionForEventSourcing;
        private readonly IMapper _mapper;

        public EsAcceptDeveloperCommandHandler(
            ISessionForEventSourcing sessionForEventSourcing, IMapper mapper)
        {
            _mapper = mapper;
            _sessionForEventSourcing = sessionForEventSourcing;
        }

        public Task<EsAcceptDeveloperCommandResponse>
            Handle(EsAcceptDeveloperCommand request, CancellationToken cancellationToken)
        {
            var developerUniqueId = _mapper.Map<DeveloperUniqueId>
                (request.DeveloperUniqueId);

            var aggregateDevloper = _sessionForEventSourcing.Get<DevloperAggregate>
                (developerUniqueId.GetAggregateKey(), null);

            if (aggregateDevloper.Version > request.Version)
                return Task.FromResult(new EsAcceptDeveloperCommandResponse
                    ($@"You sended old version.Yours {request.Version}.In Event database :{aggregateDevloper.Version}", false));

            if (aggregateDevloper.Status != DeveloperStatus.New)
                return Task.FromResult(new EsAcceptDeveloperCommandResponse
                    ($@"Devloper status in eventhistory is {aggregateDevloper.Status}.
                         Can't be Accepted", false));

            var developer = _mapper.Map<Developer>(aggregateDevloper);
            developer.Status = DeveloperStatus.Accepted;

            aggregateDevloper.Accepted(developer);
            _sessionForEventSourcing.Commit();

            return Task.FromResult(new EsAcceptDeveloperCommandResponse());

        }


    }
}
