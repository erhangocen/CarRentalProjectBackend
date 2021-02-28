using Business.Abstract;
using Core.Results.Abstract;
using Core.Results.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccsess.Abstract;
using Business.Constants;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Helpers;
using System.IO;
using Core.Utilities.Business;
using System.Linq;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.AddAsync(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.AddCarImage);
        }

        public IResult Delete(CarImage carImage)
        {
            var result = BusinessRules.Run(CarImageDelete(carImage));
            FileHelper.DeleteAsync(_carImageDal.Get(c=>c.ImageId == carImage.ImageId).ImagePath);
            if (result != null)
            {
                return result;
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.UpdateCarImage);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id));
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c=>c.ImageId == id));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.UpdateAsync(_carImageDal.Get(c=>c.ImageId == carImage.ImageId).ImagePath, file);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.DeleteCarImage);
        }
        private IResult CarImageDelete(CarImage carImage)
        {
            try
            {
                File.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
        private List<CarImage> CheckIfCarImageNull(int id)
        {
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images\default.jpg");
            var result = _carImageDal.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now } };
            }
            return _carImageDal.GetAll(p => p.CarId == id);
        }
    }
}
