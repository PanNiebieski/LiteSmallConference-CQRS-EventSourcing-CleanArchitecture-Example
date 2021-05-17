using AutoMapper;
using GeekLemonConference.Application.EventSourcing.Aggregates;
using LiteSmallConference.Application.EventSourcing.Contracts;
using LiteSmallConference.Domain.Entity;
using LiteSmallConference.Domain.ValueObjects.Identities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LiteSmallConference.Application.CQRS.Developers.CommandES.SubmitDeveloper
{
    public class EsSubmitDeveloperCommandHandler
  :
        IRequestHandler<EsSubmitDeveloperCommand, EsSubmitDeveloperCommandResponse>
    {

        private readonly ISessionForEventSourcing _sessionForEventSourcing;
        private readonly IMapper _mapper;

        public EsSubmitDeveloperCommandHandler(
            ISessionForEventSourcing sessionForEventSourcing, IMapper mapper)
        {
            _mapper = mapper;
            _sessionForEventSourcing = sessionForEventSourcing;
        }

        public async Task<EsSubmitDeveloperCommandResponse> Handle
            (EsSubmitDeveloperCommand request, CancellationToken cancellationToken)
        {
            var validator = new EsSubmitDeveloperCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                return new EsSubmitDeveloperCommandResponse(validatorResult);

            var developer = _mapper.Map<Developer>(request);

            var developerAgreggate = new DevloperAggregate(developer);

            _sessionForEventSourcing.Add<DevloperAggregate>(developerAgreggate);
            _sessionForEventSourcing.Commit();

            var ids = _mapper.Map<DeveloperIds>(developer.Ids());

            return new EsSubmitDeveloperCommandResponse(ids);
        }
    }
}
