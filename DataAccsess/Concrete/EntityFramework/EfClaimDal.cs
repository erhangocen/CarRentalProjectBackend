using Core.DataAccsess.EntityFramework;
using Core.Entities.Concrete;
using DataAccsess.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccsess.Concrete.EntityFramework
{
    public class EfClaimDal : IEntityRepositoryBase<UserOperationClaim, CarsDBContext>, IClaimDal
    { 
    }
}
