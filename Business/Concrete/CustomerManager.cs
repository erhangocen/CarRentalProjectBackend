using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResult<List<CustomerDto>> GetByDetails()
        {
            return new SuccessDataResult<List<CustomerDto>>(_customerDal.GetByDetails());
        }

        public IDataResult<Customer> Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessDataResult<Customer>(Messages.SuccessCreateAccount);
        }

        public IDataResult<Customer> Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessDataResult<Customer>(Messages.SuccessDeleteAccount);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessDataResult<Customer>(Messages.SuccessUpdateAccount);
        }
    }
}