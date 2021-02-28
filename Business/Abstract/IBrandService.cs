using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Results.Abstract;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetByBrandId(int id);
        IResult Add(Brand brand);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);
    }
}
