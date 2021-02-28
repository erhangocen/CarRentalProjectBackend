using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccsess.Abstract;
using Entities.Concrete;
using System.Text.RegularExpressions;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            var check = CheckOtherEmail(user.Email);

            var result = BusinessRules.Run(check);

            if (result != null)
            {
                return result;
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

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.SuccessUpdateAccount);
        }

        private IResult CheckOtherEmail(string email)
        {
            var result = _userDal.GetAll(u => u.Email == email).Any();
            if (result)
            {
                return new ErrorResult(Messages.EmailInvalid2);
            }

            return new SuccessResult();
        }
    }
}
