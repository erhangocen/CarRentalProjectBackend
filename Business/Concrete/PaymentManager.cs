using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Results.Abstract;
using Core.Results.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {

        IRentalService _rentalService;

        public PaymentManager(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [ValidationAspect(typeof(CreditCardValidator))]
        public IResult Pay(CreditCard card, Rental rental)
        {
            _rentalService.Add(rental);
            return new SuccessResult(Messages.AddRental);
        }
    }
}
