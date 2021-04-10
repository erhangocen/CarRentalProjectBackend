using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CreditCardValidator : AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(c => c.CardNumber.Length).LessThan(17).WithMessage(Messages.CardNumberiswrong);
            RuleFor(c => c.CardNumber.Length).GreaterThan(15).WithMessage(Messages.CardNumberiswrong);
            RuleFor(c => c.ExpMonth).LessThan(13).WithMessage(Messages.ExpMonthisWrong);
            RuleFor(c => c.ExpYear).GreaterThan(21).WithMessage(Messages.Expired);
            RuleFor(c => c.CVC.Length).LessThan(4).WithMessage(Messages.WrongCvc);
            RuleFor(c => c.CVC.Length).GreaterThan(2).WithMessage(Messages.WrongCvc);
        }
    }
}
