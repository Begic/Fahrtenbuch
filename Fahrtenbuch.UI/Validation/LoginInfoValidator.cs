using Fahrtenbuch.Data.Models;
using FluentValidation;

namespace Fahrtenbuch.UI.Validation;

public class LoginInfoValidator : AbstractValidator<LoginInfo>
{
    public LoginInfoValidator()
    {
        RuleFor(x => x.Email).NotNull().NotEmpty();
        RuleFor(x => x.Password).NotNull().NotEmpty();
    }
}