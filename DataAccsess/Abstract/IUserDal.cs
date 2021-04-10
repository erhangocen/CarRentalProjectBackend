using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccsess;
using Core.Entities.Concrete;
using Core.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccsess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        List<UserDto> GetUserDetails();
        UserDto GetSingleUserDetails(int userId);
    }
}
