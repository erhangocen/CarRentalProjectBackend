using Core.DataAccsess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccsess.Abstract
{
    public interface IProfilePhotoDal : IEntityRepository<ProfilePhoto>
    {
    }
}
