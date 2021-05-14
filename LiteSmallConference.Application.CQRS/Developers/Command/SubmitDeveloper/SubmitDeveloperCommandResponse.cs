using FluentValidation.Results;
using LiteSmallConference.Application.Common;
using LiteSmallConference.Domain.ValueObjects.Identities;

namespace LiteSmallConference.Application.CQRS.Developers.Command.SubmitDeveloper
{
    public class SubmitDeveloperCommandResponse : BaseResponse
    {
        public DeveloperIds DeveloperIds { get; set; }

        public SubmitDeveloperCommandResponse(DeveloperIds ids)
: base()
        {
            DeveloperIds = ids;
        }

        public SubmitDeveloperCommandResponse(ValidationResult validationResult)
    : base(validationResult)
        { }

        public SubmitDeveloperCommandResponse(string message)
        : base(message)
        { }

        public SubmitDeveloperCommandResponse(string message, bool success)
            : base(message, success)
        { }

        public SubmitDeveloperCommandResponse(ResponseStatus status) : base(status)
        { }
    }
}
