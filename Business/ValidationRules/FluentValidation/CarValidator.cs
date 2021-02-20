using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c=>c.DailyPrice).GreaterThan(2);
            RuleFor(c=>c.Description).NotEmpty();
            RuleFor(c=>c.Description).MinimumLength(4);
            RuleFor(c=>c.DailyPrice).GreaterThan(2);
            RuleFor(c => c.ModelYear).GreaterThanOrEqualTo(1999).WithMessage(Messages.CarYearInvalid);
            RuleFor(c => c.Description).Must(StartWithA).WithMessage("Tanımlama A ile başlamalıdır");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}