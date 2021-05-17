using FluentValidation.Results;
using LiteSmallConference.Application.Common;

namespace LiteSmallConference.Application.CQRS.Developers.CommandES.AcceptDeveloper
{
    public class EsAcceptDeveloperCommandResponse : BaseResponse
    {
        public EsAcceptDeveloperCommandResponse(ValidationResult validationResult)
: base(validationResult)
        { }

        public EsAcceptDeveloperCommandResponse(string message)
        : base(message)
        { }

        public EsAcceptDeveloperCommandResponse(string message, bool success)
            : base(message, success)
        { }

        public EsAcceptDeveloperCommandResponse()
    : base()
        {

        }

        public EsAcceptDeveloperCommandResponse(ResponseStatus status) : base(status)
        { }
    }
}
