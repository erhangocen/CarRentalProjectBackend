using Core.DataAccsess;
using Core.Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccsess.Abstract
{
    public interface IClaimDal : IEntityRepository<UserOperationClaim>
    {
    }
}
