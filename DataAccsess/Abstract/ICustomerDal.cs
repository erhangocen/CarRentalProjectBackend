using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccsess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccsess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        List<CustomerDto> GetByDetails();
    }
}
