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
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<RentalDto>> GetFullRentalDetail()
        {
            return new SuccessDataResult<List<RentalDto>>(_rentalDal.GetFullRentalDetails(),Messages.RentedCarList);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            rental.RentDate = DateTime.Now.ToString("dd MMMM yyyy");
            _rentalDal.Add(rental);
            return new SuccessResult();
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

        public IDataResult<List<RentalDto>> GetFullRentalDetail(string returndate)
        {
            return new SuccessDataResult<List<RentalDto>>(
                _rentalDal.GetFullRentalDetails(r => r.ReturnDate == returndate));
        }
    }
}