using Core.DataAccsess.EntityFramework;
using Core.Entities.Concrete;
using DataAccsess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccsess.Concrete.EntityFramework
{
    public class EfProfilePhotoDal : IEntityRepositoryBase<ProfilePhoto,CarsDBContext>, IProfilePhotoDal
    {
    }
}
