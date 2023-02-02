using FluentValidation;
using NZWalksDemo.Models.DTO;

namespace NZWalksDemo.Validations
{
    public class AddRegionRequestValidator : AbstractValidator<AddRegionRequest>
    {
        public AddRegionRequestValidator()
        {
            RuleFor(r=>r.Code).NotEmpty().NotNull().WithMessage("{property} is required");
            RuleFor(r=>r.Name).NotEmpty().NotNull().WithMessage("{property} is required");
        }
    }
}
