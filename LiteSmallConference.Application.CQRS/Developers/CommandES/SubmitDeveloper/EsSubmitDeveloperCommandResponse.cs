using FluentValidation.Results;
using LiteSmallConference.Application.Common;
using LiteSmallConference.Domain.ValueObjects.Identities;

namespace LiteSmallConference.Application.CQRS.Developers.CommandES.SubmitDeveloper
{
    public class EsSubmitDeveloperCommandResponse : BaseResponse
    {
        public DeveloperIds DeveloperIds { get; set; }

        public EsSubmitDeveloperCommandResponse(DeveloperIds ids)
: base()
        {
            DeveloperIds = ids;
        }


        public EsSubmitDeveloperCommandResponse(ValidationResult validationResult)
    : base(validationResult)
        { }

        public EsSubmitDeveloperCommandResponse(string message)
            : base(message)
        { }

        public EsSubmitDeveloperCommandResponse(string message, bool success)
            : base(message, success)
        { }

        public EsSubmitDeveloperCommandResponse() : base()
        {

        }

        public EsSubmitDeveloperCommandResponse(ResponseStatus status) : base(status)
        { }
    }
}
