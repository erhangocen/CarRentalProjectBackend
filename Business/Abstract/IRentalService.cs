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
        IDataResult<List<RentalDto>> GetFullRentalDetail();
        IDataResult<List<RentalDto>> GetFullRentalDetail(string returndate);
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        
    }
}
