using FluentValidation.Results;
using LiteSmallConference.Application.Common;

namespace LiteSmallConference.Application.CQRS.Developers.CommandES.RejectDeveloper
{
    public class EsRejectDeveloperCommandResponse : BaseResponse
    {
        public EsRejectDeveloperCommandResponse(ValidationResult validationResult)
            : base(validationResult)
        { }

        public EsRejectDeveloperCommandResponse(string message)
            : base(message)
        { }

        public EsRejectDeveloperCommandResponse(string message, bool success)
            : base(message, success)
        { }

        public EsRejectDeveloperCommandResponse() : base()
        {

        }

        public EsRejectDeveloperCommandResponse(ResponseStatus status) : base(status)
        { }
    }
}
