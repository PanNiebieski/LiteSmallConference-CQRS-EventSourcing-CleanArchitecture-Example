using FluentValidation.Results;
using LiteSmallConference.Application.Common;
using System.Collections.Generic;

namespace LiteSmallConference.Application.CQRS.Developers.Queries.GetAllDevelopers
{
    public class GetAllDevelopersQueryHandlerResponse : BaseResponse
    {
        public List<DeveloperInListViewModel> List { get; }

        public GetAllDevelopersQueryHandlerResponse
            (List<DeveloperInListViewModel> lisy) : base()
        {
            List = lisy;
        }


        public GetAllDevelopersQueryHandlerResponse(ValidationResult validationResult)
    : base(validationResult)
        { }

        public GetAllDevelopersQueryHandlerResponse(string message)
        : base(message)
        { }

        public GetAllDevelopersQueryHandlerResponse(string message, bool success)
            : base(message, success)
        { }

        public GetAllDevelopersQueryHandlerResponse(ResponseStatus status) : base(status)
        { }

    }
}
