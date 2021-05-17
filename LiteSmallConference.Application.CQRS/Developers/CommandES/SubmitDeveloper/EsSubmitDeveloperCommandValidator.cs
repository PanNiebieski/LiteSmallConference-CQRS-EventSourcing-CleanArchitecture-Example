using FluentValidation;

namespace LiteSmallConference.Application.CQRS.Developers.CommandES.SubmitDeveloper
{
    public class EsSubmitDeveloperCommandValidator
                :
    AbstractValidator<EsSubmitDeveloperCommand>
    {
        public EsSubmitDeveloperCommandValidator()
        {
            RuleFor(c => c.Name)
                .MinimumLength(1)
                .MaximumLength(100)
                .WithMessage("{PropertName} Length is beewten 1 and 100");

        }
    }
}
