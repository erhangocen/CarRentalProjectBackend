using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int id);
        IDataResult<List<CustomerDto>> GetByDetails();
        IResult Add(Customer customer);
        IResult AddUser(User user);
        IResult Update(Customer customer);
        IResult DeleteUser(User user);
        IResult Delete(Customer customer);

    }
}
