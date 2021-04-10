using Business.Abstract;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Results.Abstract;
using Core.Results.Concrete;
using Business.BussinessAspect.Autofac;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ICarImageService _carImageService;

        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;
        }
        
        //[PerformanceAspect(3)]
        [CacheAspect]
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

        public IDataResult<List<Car>> GetByBrandAndColorId(int brandId, int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId && c.ColorId == colorId));
        }

        public IDataResult<List<CarDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.GetCarDetails(),Messages.CarListedByDetail);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p=> p.CarId == id),Messages.SearchCar);
        }

        public IDataResult<List<CarDto>> GetDetailsByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.GetCarDetails(c=>c.BrandId == id));
        }


        public IDataResult<List<CarDto>> GetDetailsByColorId(int id)
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.GetCarDetails(c=>c.ColorId == id));
        }


        public IDataResult<List<CarDto>> GetDetailByColorAndBrandId(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.GetCarDetails(c=>c.BrandId == brandId && c.ColorId==colorId));
        }

        public IDataResult<CarDto> GetDetailsByCarId(int id)
        {
            return new SuccessDataResult<CarDto>(_carDal.GetSingleCarDto(id));
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("Admin")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [SecuredOperation("Admin,Editor")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDelete);
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("Admin,Editor")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdate);
        }
    }
}
