using AutoMapper;
using LiteSmallConference.Application.Common;
using LiteSmallConference.Application.Contracts.Persitence;
using LiteSmallConference.Domain.Entity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LiteSmallConference.Application.CQRS.Developers.Queries.GetDeveloper
{
    public class GetDeveloperQueryHandler
        :
        IRequestHandler<GetDeveloperQuery, GetDeveloperQueryHandlerResponse>
    {
        private readonly IDeveloperRepository _Repository;
        private readonly IMapper _mapper;
        private readonly IZEsDeveloperRepository _zEsRepository;

        public GetDeveloperQueryHandler(IDeveloperRepository Repository,
            IZEsDeveloperRepository ZEsRepository,

            IMapper mapper)
        {
            _mapper = mapper;
            _zEsRepository = ZEsRepository;
            _Repository = Repository;
        }

        public async Task<GetDeveloperQueryHandlerResponse> Handle
            (GetDeveloperQuery request, CancellationToken cancellationToken)
        {
            Developer d = null;

            if (request.DeveloperUniqueId != null)
                if (request.queryWitchDataBase == QueryWitchDataBase.WithEventSourcing)
                    d = await _zEsRepository.GetByIdAsync(request.DeveloperUniqueId);
                else
                    d = await _Repository.GetByIdAsync(request.DeveloperUniqueId);
            else if (request.DeveloperId != null)
                if (request.queryWitchDataBase == QueryWitchDataBase.WithEventSourcing)
                    d = await _zEsRepository.GetByIdAsync(request.DeveloperId);
                else
                    d = await _Repository.GetByIdAsync(request.DeveloperId);
            else
                return new GetDeveloperQueryHandlerResponse(ResponseStatus.BadQuery);

            if (d == null)
                return
                    new GetDeveloperQueryHandlerResponse(ResponseStatus.NotFoundInDataBase);

            var dMaped = _mapper.Map<DeveloperViewModel>(d);

            return new GetDeveloperQueryHandlerResponse(dMaped);

        }
    }
}
