using Core.Entities.Concrete;
using Core.Results.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProfilePhotoService
    {
        IResult Update(IFormFile formFile, ProfilePhoto profilePhoto);
        IResult Delete(ProfilePhoto profilePhoto);
        IDataResult<List<ProfilePhoto>> GetAll();
        IDataResult<ProfilePhoto> GetById(int id);
        IDataResult<ProfilePhoto> GetByUserId(int id);
    }
}
