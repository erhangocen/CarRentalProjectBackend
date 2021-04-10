using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccsess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ClaimManager : IClaimService
    {
        IClaimDal _claimDal;

        public ClaimManager(IClaimDal ClaimDal)
        {
            _claimDal = ClaimDal;
        }

        public IResult Add(UserOperationClaim claim)
        {
            _claimDal.Add(claim);
            return new SuccessResult(Messages.AddClaim);
        }

        public IResult AddUser(User user)
        {
            UserOperationClaim claim = new UserOperationClaim()
            {
                OperationClaimId = 1002,
                UserId = user.UserId
            };
            _claimDal.Add(claim);
            return new SuccessResult(Messages.AddClaim);
        }

        public IResult Delete(UserOperationClaim claim)
        {
            _claimDal.Delete(claim);
            return new SuccessResult(Messages.DeleteClaim);
        }

        public IResult DeleteUser(User user)
        {
            List<UserOperationClaim> claims = _claimDal.GetAll(c => c.UserId == user.UserId).ToList();
            foreach (var claim in claims)
            {
                _claimDal.Delete(claim);
            }
            return new SuccessResult(Messages.DeleteClaim);
        }

        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_claimDal.GetAll());
        }

        public IDataResult<List<UserOperationClaim>> GetByClaimId(int id)
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_claimDal.GetAll(c=>c.OperationClaimId == id));
        }

        public IDataResult<List<UserOperationClaim>> GetByUserId(int id)
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_claimDal.GetAll(c => c.UserId == id));
        }

        public IResult Update(UserOperationClaim claim)
        {
            _claimDal.Update(claim);
            return new SuccessResult(Messages.updateClaim);
        }
    }
}
