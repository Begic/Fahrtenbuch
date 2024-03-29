﻿using Fahrtenbuch.Data.Models;
using FluentValidation;

namespace Fahrtenbuch.UI.Validation;

public class EditTripInfoValidator : AbstractValidator<EditTripInfo>
{
    public EditTripInfoValidator()
    {
        RuleFor(x => x.Date).NotEmpty().NotNull();
        RuleFor(x => x.StartTimeStamp).NotEmpty().NotNull();
        RuleFor(x => x.EndTimeStamp).GreaterThan(x=> x.StartTimeStamp);
        RuleFor(x => x.PurposeOfTrip).NotEmpty().NotNull();
        RuleFor(x => x.TravelRoute).NotEmpty().NotNull();
        RuleFor(x => x.DepartureMileage).NotEmpty().NotNull();
        RuleFor(x => x.ArrivalMileage).GreaterThan(x=> x.DepartureMileage);
        RuleFor(x => x.CompanyCarId).NotEmpty().NotNull();
    }
}