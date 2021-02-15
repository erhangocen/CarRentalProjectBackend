using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccsess;
using Entities.Concrete;

namespace DataAccsess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {

    }
}
