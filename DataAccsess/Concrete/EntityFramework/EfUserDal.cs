using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccsess.EntityFramework;
using Core.Entities.Concrete;
using DataAccsess.Abstract;
using Entities.Concrete;
using System.Linq;
using Entities.Dtos;
using Core.Results.Abstract;

namespace DataAccsess.Concrete.EntityFramework
{
    public class EfUserDal : IEntityRepositoryBase<User, CarsDBContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (CarsDBContext context = new CarsDBContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim 
                             { 
                                Id = operationClaim.Id, 
                                Name = operationClaim.Name 
                             };
                 return result.ToList();
            }   
        }

        public List<UserDto> GetUserDetails()
        {
            using (CarsDBContext context = new CarsDBContext())
            {
                var result = from u in context.Users
                             join o in context.UserOperationClaims
                             on u.UserId equals o.UserId
                             join cl in context.OperationClaims
                             on o.OperationClaimId equals cl.Id
                             join c in context.Customers
                             on u.UserId equals c.UserId
                             select new UserDto
                             {
                                 UserId = u.UserId,
                                 ClaimId = cl.Id,
                                 CustomerId = c.CustomerId, 
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 CompanyName = c.CompanyName,
                                 ClaimName = cl.Name,
                                 FindeksPoint = c.FindeksPoint
                             };
                return result.ToList();
            }
        }

        public UserDto GetSingleUserDetails(int userId)
        {
            using (CarsDBContext context = new CarsDBContext())
            {
                var result = from u in context.Users.Where(u=>u.UserId == userId)
                             join o in context.UserOperationClaims
                             on u.UserId equals o.UserId
                             join cl in context.OperationClaims
                             on o.OperationClaimId equals cl.Id
                             join c in context.Customers
                             on u.UserId equals c.UserId
                             select new UserDto
                             {
                                 UserId = u.UserId,
                                 ClaimId = cl.Id,
                                 CustomerId = c.CustomerId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 CompanyName = c.CompanyName,
                                 ClaimName = cl.Name,
                                 FindeksPoint = c.FindeksPoint
                             };
                return result.FirstOrDefault();
            }
        }
    }
}
