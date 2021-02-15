using Core.DataAccsess;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccsess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDto> GetCarDetails();
    }
}
