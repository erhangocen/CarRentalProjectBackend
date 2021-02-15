using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccsess.EntityFramework;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccsess.Concrete.EntityFramework
{
    public class EfRentalDal : IEntityRepositoryBase<Rental,CarsDBContext>, IRentalDal
    {
        public List<RentalDto> GetFullRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarsDBContext context = new CarsDBContext())
            {
                var result =
                    from r in filter == null ? context.Rentals : context.Rentals.Where(filter)
                    join c in context.Cars
                        on r.CarId equals c.CarId
                    join b in context.Brands
                        on c.BrandId equals b.BrandId
                    join cl in context.Colors
                        on c.ColorId equals cl.ColorId
                    join cus in context.Customers
                        on r.CustomerId equals cus.CustomerId
                    join u in context.Users
                        on cus.UserId equals u.UserId
                    select new RentalDto()
                    {
                        Car = cl.ColorName +" "+ b.BrandName,
                        CustomerName = u.FirstName +" "+ u.LastName,
                        RentDate = r.RentDate,
                        ReturnDate = r.ReturnDate
                    };

                return result.ToList();
            }
        }
    }
}
