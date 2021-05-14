using FluentValidation.Results;
using LiteSmallConference.Application.Common;

namespace LiteSmallConference.Application.CQRS.Developers.Command.AcceptDeveloper
{
    public class AcceptDeveloperCommandResponse : BaseResponse
    {
        public AcceptDeveloperCommandResponse(ValidationResult validationResult)
: base(validationResult)
        { }

        public AcceptDeveloperCommandResponse(string message)
        : base(message)
        { }

        public AcceptDeveloperCommandResponse(string message, bool success)
            : base(message, success)
        { }

        public AcceptDeveloperCommandResponse()
    : base()
        {

        }

        public AcceptDeveloperCommandResponse(ResponseStatus status) : base(status)
        { }
    }
}
