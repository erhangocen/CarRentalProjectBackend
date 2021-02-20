using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Business.Constants;
using Core.Results.Concrete;
using DataAccsess.Abstract;
using DataAccsess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
	public class UserValidator : AbstractValidator<User>
	{

		IUserDal userDal = new EfUserDal();

		public UserValidator()
		{
			RuleFor(u => u.FirstName.Length).GreaterThanOrEqualTo(3).WithMessage(Messages.NameInvalid);
			RuleFor(u => u.LastName.Length).GreaterThanOrEqualTo(2).WithMessage(Messages.SurnameInvalid);
			RuleFor(u => u.Password.Length).GreaterThanOrEqualTo(5).WithMessage(Messages.PasswordInvalid);
			RuleFor(u =>u.Email).Must(isEmail).WithMessage(Messages.EmailInvalid);
			RuleFor(u => u.Email).Must(checkOtherEmail).WithMessage(Messages.EmailInvalid2);
		}
		private bool checkOtherEmail(string arg)
		{
			var otherUsers = userDal.GetAll();
			var emails = otherUsers.Find(e => e.Email == arg);
			return emails.Email.Equals(null);
		}

		private bool isEmail(string arg)
		{
			return arg.Contains("@");
		}
	}
}
