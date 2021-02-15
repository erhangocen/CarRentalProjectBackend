using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccsess.Abstract;
using Entities.Concrete;
using System.Text.RegularExpressions;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (user.FirstName.Length<3)
            {
                return new ErrorResult(Messages.NameInvalid);

            }
            if (user.LastName.Length<3)
            {
                return new ErrorResult(Messages.SurnameInvalid);
            }
            if (user.Password.Length<5)
            {
                return new ErrorResult(Messages.PasswordInvalid);
            }
            if (!Regex.IsMatch(user.Email,"@"))
            {
                return new ErrorResult(Messages.EmailInvalid);
            }

            var verify = _userDal.GetAll();
            foreach (var okuser in verify)
            {
                if (okuser.Email == user.Email)
                {
                    return new ErrorResult(Messages.EmailInvalid2);
                }
            }

            _userDal.Add(user);
            return new SuccessResult(Messages.SuccessCreateAccount);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.SuccessDeleteAccount);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.SuccessUpdateAccount);
        }
    }
}
