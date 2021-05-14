using FluentValidation.Results;
using LiteSmallConference.Application.Common;

namespace LiteSmallConference.Application.CQRS.Developers.Queries.GetDeveloper
{
    public class GetDeveloperQueryHandlerResponse : BaseResponse
    {
        public DeveloperViewModel Developer { get; }

        public GetDeveloperQueryHandlerResponse(DeveloperViewModel developer)
    : base()
        {
            Developer = developer;
        }

        public GetDeveloperQueryHandlerResponse(ValidationResult validationResult)
    : base(validationResult)
        { }

        public GetDeveloperQueryHandlerResponse(string message)
        : base(message)
        { }

        public GetDeveloperQueryHandlerResponse(string message, bool success)
            : base(message, success)
        { }

        public GetDeveloperQueryHandlerResponse(ResponseStatus status) : base(status)
        { }
    }
}
