using Core.DataAccsess.EntityFramework;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccsess.Concrete.EntityFramework
{
    public class EfCarDal : IEntityRepositoryBase<Car, CarsDBContext>, ICarDal
    {
        public List<CarDto> GetCarDetails()
        {
            using (CarsDBContext context = new CarsDBContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             select new CarDto
                             {
                                 CarName = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName  = cl.ColorName,
                                 ModelYear  = c.ModelYear,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
