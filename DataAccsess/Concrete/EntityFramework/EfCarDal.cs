using Core.DataAccsess.EntityFramework;
using Core.Results.Abstract;
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
        public List<CarDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (CarsDBContext context = new CarsDBContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             select new CarDto
                             {
                                 CarId = c.CarId,
                                 CarName = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName  = cl.ColorName,
                                 ModelYear  = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = context.CarImages.Where(i=>i.CarId == c.CarId).FirstOrDefault().ImagePath,
                                 MinFindeksPoint = c.MinFindeksPoint
                             };
                return result.ToList();
            }
        }

        public CarDto GetSingleCarDto(int carId)
        {
            using (CarsDBContext context = new CarsDBContext())
            {
                var result = from c in context.Cars.Where(c=>c.CarId == carId)
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             select new CarDto
                             {
                                 CarId = c.CarId,
                                 CarName = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice
                             };
                return result.SingleOrDefault();
            }
        }
    }
}
