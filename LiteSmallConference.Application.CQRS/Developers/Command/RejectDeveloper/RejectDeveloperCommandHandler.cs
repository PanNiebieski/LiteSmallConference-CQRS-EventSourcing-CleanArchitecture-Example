using AutoMapper;
using LiteSmallConference.Application.Contracts.Persitence;
using LiteSmallConference.Domain.ValueObjects;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LiteSmallConference.Application.CQRS.Developers.Command.RejectDeveloper
{
    public class RejectDeveloperCommandHandler
        :
        IRequestHandler<RejectDeveloperCommand, RejectDeveloperCommandResponse>
    {
        private readonly IDeveloperRepository _callRepository;
        private readonly IMapper _mapper;

        public RejectDeveloperCommandHandler(IDeveloperRepository callRepository,
            IMapper mapper)
        {
            _callRepository = callRepository;
            _mapper = mapper;
        }

        public async Task<RejectDeveloperCommandResponse> Handle
            (RejectDeveloperCommand request, CancellationToken cancellationToken)
        {
            var developerUniqueId = _mapper.Map<DeveloperUniqueId>
                (request.DeveloperUniqueId);

            await _callRepository.SaveRejectionAsync
                (developerUniqueId);

            return new RejectDeveloperCommandResponse();
        }
    }
}
