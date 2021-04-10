using Core.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCardSevice
    {      
        IDataResult<CreditCard> GetById(int id);

        IDataResult<List<CreditCard>> GetAllByCustomerId(int customerId);

        IResult Add(CreditCard creditCard);
    }
}
