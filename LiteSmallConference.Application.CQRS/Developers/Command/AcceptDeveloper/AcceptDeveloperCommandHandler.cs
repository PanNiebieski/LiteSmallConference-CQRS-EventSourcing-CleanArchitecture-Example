using AutoMapper;
using LiteSmallConference.Application.Contracts.Persitence;
using LiteSmallConference.Domain.ValueObjects;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LiteSmallConference.Application.CQRS.Developers.Command.AcceptDeveloper
{
    public class AcceptDeveloperCommandHandler
             :
        IRequestHandler<AcceptDeveloperCommand, AcceptDeveloperCommandResponse>
    {
        private readonly IDeveloperRepository _callRepository;
        private readonly IMapper _mapper;

        public AcceptDeveloperCommandHandler(IDeveloperRepository callRepository,
            IMapper mapper)
        {
            _callRepository = callRepository;
            _mapper = mapper;
        }

        public async Task<AcceptDeveloperCommandResponse> Handle
            (AcceptDeveloperCommand request, CancellationToken cancellationToken)
        {
            var developerUniqueId = _mapper.Map<DeveloperUniqueId>
                (request.DeveloperUniqueId);

            await _callRepository.SaveAcceptenceAsync
                (developerUniqueId);

            return new AcceptDeveloperCommandResponse();
        }
    }
}
