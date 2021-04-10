using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<List<OperationClaim>> GetOperationClaims(User user);
        IDataResult<User> GetByMail(string email);
        IDataResult<User> GetById(int id);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<List<UserDto>> GetUserDetails();
        IDataResult<UserDto> GetSingleUserDetail(int userId);
    }
}
