using Business.Abstract;
using Business.BussinessAspect.Autofac;
using Business.Constants;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {

        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        [SecuredOperation("Customer")]
        public IResult Add(Contact contact)
        {
            _contactDal.Add(contact);
            return new SuccessResult(Messages.SendMessage);
        }

        [SecuredOperation("Admin")]
        public IResult Delete(Contact contact)
        {
            _contactDal.Delete(contact);
            return new SuccessResult(Messages.deleteMessage);
        }

        [SecuredOperation("Admin")]
        public IDataResult<List<Contact>> GetAll()
        {
            return new SuccessDataResult<List<Contact>>(_contactDal.GetAll());
        }

        [SecuredOperation("Admin")]
        public IDataResult<List<ContactDto>> GetContactsDetails()
        {
            return new SuccessDataResult<List<ContactDto>>(_contactDal.GetContactDetails());
        }
    }
}
