using System;
using System.Collections.Generic;
using System.Text;
using Core.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDto>> GetFullRentalDetails();
        IDataResult<List<RentalDto>> GetRentalsByUser(int id);
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IResult CheckCarStatus(Rental rental);
    }
}
