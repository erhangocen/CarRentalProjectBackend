using System;
using System.Collections.Generic;
using System.Text;
using Core.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<CustomerDto>> GetByDetails();
        IDataResult<Customer> Add(Customer customer);
        IDataResult<Customer> Update(Customer customer);
        IDataResult<Customer> Delete(Customer customer);

    }
}
