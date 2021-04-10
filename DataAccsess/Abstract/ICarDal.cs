using Core.DataAccsess;
using Core.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccsess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDto> GetCarDetails(Expression<Func<Car, bool>> filter = null);
        CarDto GetSingleCarDto(int carId);
    }
}
