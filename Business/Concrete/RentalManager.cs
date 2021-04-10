using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Results.Abstract;
using Core.Results.Concrete;
using Core.Utilities.Business;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;
        private ICarService _carService;
        private ICustomerService _customerService;

        public RentalManager(IRentalDal rentalDal, ICarService carService, ICustomerService customerService)
        {
            _rentalDal = rentalDal;
            _customerService = customerService;
            _carService = carService;
        }

        public IDataResult<List<RentalDto>> GetFullRentalDetails()
        {
            return new SuccessDataResult<List<RentalDto>>(_rentalDal.GetFullRentalDetails());
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CheckFindeksPoint(rental), IsRentable(rental));
            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.AddRental);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentUpdate);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentDelete);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<RentalDto>> GetRentalsByUser(int id)
        {
            return new SuccessDataResult<List<RentalDto>>(_rentalDal.GetFullRentalDetails(r => r.CustomerId == id));
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult IsRentable(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId);

            if (result.Any(r => r.ReturnDate >= rental.RentDate))
            {
                return new ErrorResult(Messages.RentalNotAvailable);
            } 
            return new SuccessResult();
        }


        public IResult CheckFindeksPoint(Rental rental)
        {
            var car = _carService.GetById(rental.CarId).Data;
            var findeksPoint = _customerService.GetById(rental.CustomerId).Data.FindeksPoint;

            if(car.MinFindeksPoint > findeksPoint)
            {
                return new ErrorResult(Messages.NotEnoughFindex);
            }
            return new SuccessResult();
        }

        public IResult CheckCarStatus(Rental rental)
        {
            if (_rentalDal.CheckCarStatus(rental.CarId, rental.RentDate, rental.ReturnDate))
            {
                return new SuccessResult(Messages.RentalDateOk);
            }
            return new ErrorResult(Messages.RentalReturnDateError);
        }
    }
}