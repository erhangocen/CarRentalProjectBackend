using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
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

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.SuccessCreateAccount);
        }

        public IResult AddUser(User user)
        {
            Customer newCustomer = new Customer() 
            { 
                UserId = user.UserId, 
                FindeksPoint = new Random().Next(701,1901) 
            };

            _customerDal.Add(newCustomer);
            return new SuccessResult(Messages.SuccessCreateAccount);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.SuccessDeleteAccount);
        }

        public IResult DeleteUser(User user)
        {
            Customer customer = _customerDal.Get(c => c.UserId == user.UserId);

            _customerDal.Delete(customer);
            return new SuccessResult(Messages.SuccessDeleteAccount);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c=>c.CustomerId == id));
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.SuccessUpdateAccount);
        }

    }
}
