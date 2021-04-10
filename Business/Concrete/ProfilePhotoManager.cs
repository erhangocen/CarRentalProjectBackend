using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Results.Abstract;
using Core.Results.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using DataAccsess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Business.Concrete
{
    public class ProfilePhotoManager : IProfilePhotoService
    {

        IProfilePhotoDal _profilePhotoDal;

        public ProfilePhotoManager(IProfilePhotoDal profilePhotoDal)
        {
            _profilePhotoDal = profilePhotoDal;
        }

        public IResult Delete(ProfilePhoto profilePhoto)
        {
            var imagePath = _profilePhotoDal.Get(p => p.Id == profilePhoto.Id).ImagePath;
            var fullPath = @"C:\Users\Erhan\Desktop\C#\CarProject\WebAPI\wwwroot\" + imagePath;
            PPHelper.Delete(fullPath);
            //if (result != null)
            //{
            //    return result;
            //}
            _profilePhotoDal.Delete(profilePhoto);
            return new SuccessResult(Messages.PPDelete);
        }

        public IDataResult<List<ProfilePhoto>> GetAll()
        {
            return new SuccessDataResult<List<ProfilePhoto>>(_profilePhotoDal.GetAll());
        }

        public IDataResult<ProfilePhoto> GetById(int id)
        {
            return new SuccessDataResult<ProfilePhoto>(_profilePhotoDal.Get(p=>p.Id == id));
        }

        public IDataResult<ProfilePhoto> GetByUserId(int id)
        {
            return new SuccessDataResult<ProfilePhoto>(CheckIfCarImageNull(id));
        }

        public IResult Update(IFormFile formFile, ProfilePhoto profilePhoto)
        {
            
            var oldImage = _profilePhotoDal.Get(p => p.UserId == profilePhoto.UserId);
            if (oldImage != null)
            {
                _profilePhotoDal.Delete(oldImage); 
            }    
            profilePhoto.ImagePath = PPHelper.Add(formFile);

            var data = profilePhoto.ImagePath.Split('\\').LastOrDefault();
            profilePhoto.ImagePath = "/Images/ProfilePhotos/" + data;

            profilePhoto.Date = DateTime.Now;
            _profilePhotoDal.Add(profilePhoto);
               
            return new SuccessResult(Messages.PPSuccesfullUpdate);
        }

        //private IResult ProfilePhotoDelete(ProfilePhoto profilePhoto)
        //{
        //    try
        //    {
        //        File.Delete(profilePhoto.ImagePath);
        //    }
        //    catch (Exception exception)
        //    {

        //        return new ErrorResult(exception.Message);
        //    }

        //    return new SuccessResult();
        //}

        private ProfilePhoto CheckIfCarImageNull(int id)
        {
            string path =  @"Images\ProfilePhotos\default.jpg";

            var result = _profilePhotoDal.Get(p => p.UserId == id);
            if (result == null)
            {
                return new ProfilePhoto { Id = id, ImagePath = path, Date = DateTime.Now } ;
            }
            return result;
        }
    }
}
