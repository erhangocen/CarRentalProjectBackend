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

        public bool CheckCarStatus(int carId, DateTime rentDate, DateTime returnDate)
        {
            using (CarsDBContext context = new CarsDBContext())
            {
                bool checkReturnDateIsNull = context.Set<Rental>().Any(p => p.CarId == carId && p.ReturnDate == null);
                bool isValidRentDate = context.Set<Rental>()
                    .Any(r => r.CarId == carId && (
                            (rentDate >= r.RentDate && rentDate <= r.ReturnDate) ||
                            (returnDate >= r.RentDate && returnDate <= r.ReturnDate) ||
                            (r.RentDate >= rentDate && r.RentDate <= returnDate)
                            )
                    );

                if ((!checkReturnDateIsNull) && (!isValidRentDate))
                {
                    return true;
                }

                return false;
            }
        }


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
                        RentalId = r.RentalId,
                        CarId = c.CarId,
                        CustomerId = cus.CustomerId,
                        CarName = c.Description,
                        CustomerName = u.FirstName +" "+ u.LastName,
                        RentDate = r.RentDate,
                        ReturnDate = r.ReturnDate
                    };

                return result.ToList();
            }
        }
    }
}
