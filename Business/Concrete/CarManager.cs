using Business.Abstract;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using Core.Results.Abstract;
using Core.Results.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice > 0)); 
        }

        public IDataResult<List<Car>> GetByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id),Messages.CarListedByBrand);
        }

        public IDataResult<List<Car>> GetByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id),Messages.CarListedByColor); 
        }

        public IDataResult<List<CarDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 16)
            {
                return new ErrorDataResult<List<CarDto>>(Messages.ErrorDataResult);
            }

            return new SuccessDataResult<List<CarDto>>(_carDal.GetCarDetails(),Messages.CarListedByDetail);
        }

        public IResult Add(Car car)
        {
            if (Int32.Parse(car.ModelYear) <1998)
            {
                return new ErrorResult(Messages.CarYearInvalid);
            }

            _carDal.Add(car);

            return new Result(true,Messages.CarAdded);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p=> p.CarId == id),Messages.SearchCar);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdate);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDelete);
        }
    }
}
