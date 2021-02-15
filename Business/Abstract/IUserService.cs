using System;
using System.Collections.Generic;
using System.Text;
using Core.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IDataResult<List<User>> GetAll();
        IResult Update(User user);
        IResult Delete(User user);
    }
}
