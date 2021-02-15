using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Results.Abstract;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetByColorId(int id);
        IDataResult<List<Car>> GetByBrandId(int id);
        IDataResult<Car> GetById(int id);
        IDataResult<List<CarDto>> GetCarDetails();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
    }
}
