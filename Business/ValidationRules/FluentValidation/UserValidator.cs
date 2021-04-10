using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Results.Concrete;
using DataAccsess.Abstract;
using DataAccsess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
	public class UserValidator : AbstractValidator<User>
	{

        public UserValidator()
		{
			RuleFor(u => u.FirstName.Length).GreaterThanOrEqualTo(3).WithMessage(Messages.NameInvalid);
			RuleFor(u => u.LastName.Length).GreaterThanOrEqualTo(2).WithMessage(Messages.SurnameInvalid);
			RuleFor(u => u.PasswordHash.Length).GreaterThanOrEqualTo(5).WithMessage(Messages.PasswordInvalid);
			RuleFor(u =>u.Email).Must(isEmail).WithMessage(Messages.EmailInvalid);
        }

        private bool isEmail(string arg)
		{
			return arg.Contains("@");
		}
	}
}
