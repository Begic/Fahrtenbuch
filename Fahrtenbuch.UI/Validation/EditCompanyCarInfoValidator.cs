using Fahrtenbuch.Data.Models;
using FluentValidation;

namespace Fahrtenbuch.UI.Validation;

public class EditCompanyCarInfoValidator : AbstractValidator<EditCompanyCarInfo>
{
    public EditCompanyCarInfoValidator()
    {
        RuleFor(x => x.Brand).NotEmpty().NotNull();
        RuleFor(x => x.Type).NotEmpty().NotNull();
        RuleFor(x => x.LicensePlate).NotEmpty().NotNull();
    }
}