using FluentValidation;
using VillaProject.Application.Features.Villas.Commands;

namespace VillaProject.Application.Validators.Villas
{
    public class CreateVillaCommandRequestValidator : AbstractValidator<CreateVillaCommandRequest>
    {
        public CreateVillaCommandRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(50);
        }
    }
}
