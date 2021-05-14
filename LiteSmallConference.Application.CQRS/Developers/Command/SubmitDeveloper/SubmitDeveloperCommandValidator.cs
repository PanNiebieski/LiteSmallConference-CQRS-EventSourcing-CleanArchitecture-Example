using FluentValidation;

namespace LiteSmallConference.Application.CQRS.Developers.Command.SubmitDeveloper
{
    public class SubmitDeveloperCommandValidator
        :
    AbstractValidator<SubmitDeveloperCommand>
    {
        public SubmitDeveloperCommandValidator()
        {
            RuleFor(c => c.Name)
                .MinimumLength(1)
                .MaximumLength(100)
                .WithMessage("{PropertName} Length is beewten 1 and 100");

        }
    }
}
