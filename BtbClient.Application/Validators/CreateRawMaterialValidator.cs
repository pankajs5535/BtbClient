using BtbClient.Application.DTOs.RawMaterialDtos;
using FluentValidation;

namespace BtbClient.Application.Validators
{
    public class CreateRawMaterialValidator : AbstractValidator<CreateRawMaterialDto>
    {
        public CreateRawMaterialValidator()
        {
            RuleFor(x => x.MaterialCode)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.MaterialName)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.MaterialType)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Uom)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.UnitCost)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.MinStockLevel)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.MaxStockLevel)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.ReorderPoint)
                .GreaterThanOrEqualTo(0);
        }
    }
}