using Core.Entities.Concrete;
using Core.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IClaimService
    {
        IDataResult<List<UserOperationClaim>> GetAll();
        IDataResult<List<UserOperationClaim>> GetByClaimId(int id);
        IDataResult<List<UserOperationClaim>> GetByUserId(int id);
        IResult Add(UserOperationClaim claim);
        IResult AddUser(User user);
        IResult Update(UserOperationClaim claim);
        IResult Delete(UserOperationClaim claim);
        IResult DeleteUser(User user);
        
    }
}
