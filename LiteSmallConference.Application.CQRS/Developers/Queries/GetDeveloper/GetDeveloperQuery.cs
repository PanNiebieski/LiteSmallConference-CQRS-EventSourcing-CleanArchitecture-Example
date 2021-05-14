using LiteSmallConference.Domain.ValueObjects;
using MediatR;

namespace LiteSmallConference.Application.CQRS.Developers.Queries.GetDeveloper
{
    public class GetDeveloperQuery : IRequest<GetDeveloperQueryHandlerResponse>
    {
        public DeveloperId DeveloperId { get; set; }
        public DeveloperUniqueId DeveloperUniqueId { get; set; }

        public QueryWitchDataBase queryWitchDataBase { get; set; }
    }
}
