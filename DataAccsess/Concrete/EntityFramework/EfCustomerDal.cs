using Core.DataAccsess.EntityFramework;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccsess.Concrete.EntityFramework
{
    public class EfCustomerDal : IEntityRepositoryBase<Customer,CarsDBContext>, ICustomerDal
    {
        public List<CustomerDto> GetByDetails()
        {
            using (CarsDBContext context = new CarsDBContext())
            {
                var result =
                    from c in context.Customers
                    join u in context.Users
                        on c.UserId equals u.UserId
                    select new CustomerDto
                    {
                        FullName = u.FirstName + u.LastName,
                        Company = c.CompanyName
                    };
                return result.ToList();
            }
        }
    }
}
