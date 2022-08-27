using FluentValidation;
using VillaProject.Application.Features.Villas.Commands.UpdateVillaCommand;

namespace VillaProject.Application.Validators.Villas
{
    public class UpdateVillaCommandRequestValidator : AbstractValidator<UpdateVillaCommandRequest>
    {
        public UpdateVillaCommandRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(50);
        }
    }
}
