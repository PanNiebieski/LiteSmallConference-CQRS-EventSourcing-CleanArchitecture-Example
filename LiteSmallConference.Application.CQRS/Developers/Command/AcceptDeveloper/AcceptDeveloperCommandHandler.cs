using AutoMapper;
using LiteSmallConference.Application.Contracts.Persitence;
using LiteSmallConference.Domain.ValueObject;
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


            var developer = await _callRepository.GetByIdAsync(developerUniqueId);

            if (developer.Status == DeveloperStatus.New)
                await _callRepository.SaveAcceptenceAsync
                    (developerUniqueId);
            else
            {
                return new AcceptDeveloperCommandResponse("Can't Accept Developer " +
                    "that is alread " + developer.Status.ToString(), false);
            }

            return new AcceptDeveloperCommandResponse();
        }
    }
}
