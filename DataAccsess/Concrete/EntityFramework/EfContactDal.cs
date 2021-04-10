using Core.DataAccsess.EntityFramework;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccsess.Concrete.EntityFramework
{
    public class EfContactDal : IEntityRepositoryBase<Contact, CarsDBContext>, IContactDal
    {
        public List<ContactDto> GetContactDetails()
        {
            using (CarsDBContext context = new CarsDBContext())
            {
                var result = from c in context.Contacts
                             join u in context.Users
                             on c.UserId equals u.UserId
                             select new ContactDto
                             {
                                 Id = c.Id,
                                 UserId = u.UserId,
                                 FullName = u.FirstName + " " + u.LastName,
                                 ContInfo = c.ContInfo,
                                 Message = c.Message,
                                 ImagePath = context.ProfilePhotos.Where(i => i.UserId == u.UserId).FirstOrDefault().ImagePath
                             };
                return result.ToList();
            }
        }
    }
}
