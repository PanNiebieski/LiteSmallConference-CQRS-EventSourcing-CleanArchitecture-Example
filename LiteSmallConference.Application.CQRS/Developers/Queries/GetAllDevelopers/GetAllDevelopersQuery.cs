using LiteSmallConference.Application.Contracts.Persitence;
using MediatR;

namespace LiteSmallConference.Application.CQRS.Developers.Queries.GetAllDevelopers
{
    public class GetAllDevelopersQuery : IRequest<GetAllDevelopersQueryHandlerResponse>
    {
        public FilterDeveloperStatus Filter { get; set; }

        public QueryWitchDataBase queryWitchDataBase { get; set; }
    }
}
