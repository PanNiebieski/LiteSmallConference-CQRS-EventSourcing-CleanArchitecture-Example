using AutoMapper;
using LiteSmallConference.Application.Common;
using LiteSmallConference.Application.Contracts.Persitence;
using LiteSmallConference.Domain.Entity;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LiteSmallConference.Application.CQRS.Developers.Queries.GetAllDevelopers
{
    public class GetAllDevelopersQueryHandler
        :
        IRequestHandler<GetAllDevelopersQuery,
            GetAllDevelopersQueryHandlerResponse>
    {
        private readonly IDeveloperRepository _Repository;
        private readonly IMapper _mapper;
        private readonly IZEsDeveloperRepository _zEsRepository;

        public GetAllDevelopersQueryHandler(IDeveloperRepository callRepository,
            IZEsDeveloperRepository ZEscallRepository,

            IMapper mapper)
        {
            _mapper = mapper;
            _zEsRepository = ZEscallRepository;
            _Repository = callRepository;
        }

        public async Task<GetAllDevelopersQueryHandlerResponse> Handle(GetAllDevelopersQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Developer> listresult;

            if (request.queryWitchDataBase == QueryWitchDataBase.WithEventSourcing)
                listresult = await _zEsRepository.GetCollectionAsync(request.Filter);
            else
                listresult = await _Repository.GetCollectionAsync(request.Filter);

            if (listresult == null)
                return new GetAllDevelopersQueryHandlerResponse
                    (ResponseStatus.NotFoundInDataBase);


            var allordered = listresult.OrderBy(x => x.Id);
            var allmaped = _mapper.Map<List<DeveloperInListViewModel>>(listresult);
            return new GetAllDevelopersQueryHandlerResponse(allmaped);

        }
    }
}
