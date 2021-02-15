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
        List<RentalDto> GetFullRentalDetails(Expression<Func<Rental, bool>> filter = null);
    }
}
