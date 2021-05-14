using FluentValidation.Results;
using LiteSmallConference.Application.Common;

namespace LiteSmallConference.Application.CQRS.Developers.Command.RejectDeveloper
{
    public class RejectDeveloperCommandResponse : BaseResponse
    {
        public RejectDeveloperCommandResponse(ValidationResult validationResult)
: base(validationResult)
        { }

        public RejectDeveloperCommandResponse(string message)
        : base(message)
        { }

        public RejectDeveloperCommandResponse(string message, bool success)
            : base(message, success)
        { }

        public RejectDeveloperCommandResponse()
    : base()
        {

        }

        public RejectDeveloperCommandResponse(ResponseStatus status) : base(status)
        { }
    }
}
