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
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Description).MinimumLength(4);
            RuleFor(c => c.ModelYear).GreaterThanOrEqualTo(1999).WithMessage(Messages.CarYearInvalid);
            RuleFor(c => c.MinFindeksPoint).LessThanOrEqualTo(1900);
            RuleFor(c => c.MinFindeksPoint).GreaterThan(0);
            //RuleFor(c => c.Description).Must(StartWithA).WithMessage("Tanımlama A ile başlamalıdır");
        }

        //private bool StartWithA(string arg)
        //{
        //    return arg.StartsWith("A");
        //}
    }
}