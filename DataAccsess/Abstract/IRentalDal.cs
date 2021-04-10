using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccsess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccsess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        bool CheckCarStatus(int carId, DateTime rentDate, DateTime returnDate);
        List<RentalDto> GetFullRentalDetails(Expression<Func<Rental, bool>> filter = null);
    }
}
