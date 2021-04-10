using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Results.Abstract;
using Core.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;
        ICustomerService _customerService;
        IClaimService _claimService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, ICustomerService customerService, IClaimService claimService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _claimService = claimService;
            _customerService = customerService;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccsessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email).Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.WrongPassword);  
            }
            return new SuccessDataResult<User>(userToCheck, Messages.SuccesLogin);
        }

        [ValidationAspect(typeof(RegisterValidator))]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userService.Add(user);
            _customerService.AddUser(user);
            _claimService.AddUser(user);
            return new SuccessDataResult<User>(user, Messages.SuccesRegister);
        }

        [ValidationAspect(typeof(RegisterValidator))]
        public IDataResult<User> Update(UserForUpdateDto userForUpdateDto)
        {
            User user = _userService.GetById(userForUpdateDto.UserId).Data;
            user.FirstName = userForUpdateDto.FirstName;
            user.LastName = userForUpdateDto.LastName;

            _userService.Update(user);
            return new SuccessDataResult<User>(user, Messages.SuccesUpdateUser);
        }

        public IResult UserExist(string email)
        {
            if (_userService.GetByMail(email).Data != null)
            {
                return new ErrorDataResult<User>(Messages.UserAlredyExist);
            }
            return new SuccessResult();
        }
    }
}
