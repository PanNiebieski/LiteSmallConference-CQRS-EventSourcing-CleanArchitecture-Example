using AutoMapper;
using LiteSmallConference.Application.Contracts.Persitence;
using LiteSmallConference.Domain.ValueObject;
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

            var developer = await _callRepository.GetByIdAsync(developerUniqueId);

            if (developer.Status == DeveloperStatus.New)
                await _callRepository.SaveRejectionAsync
                    (developerUniqueId);
            else
            {
                return new RejectDeveloperCommandResponse("Can't Reject Developer " +
                    "that is alread " + developer.Status.ToString(), false);
            }

            return new RejectDeveloperCommandResponse();
        }
    }
}
