using Core.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IContactService
    {
        IDataResult<List<Contact>> GetAll();
        IDataResult<List<ContactDto>> GetContactsDetails();
        IResult Add(Contact contact);
        IResult Delete(Contact contact);
    }
}
