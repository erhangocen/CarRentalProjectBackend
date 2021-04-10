using Core.Results.Abstract;
using Core.Results.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class PPHelper
    {

        public static string CreateGuidFilePath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;
            string path = Environment.CurrentDirectory + @"\wwwroot\Images\ProfilePhotos";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string newPath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + fileExtension;
            string result = $@"{path}\{newPath}";
            return result;
        }

        public static string Add(IFormFile file)
        {
            var sourcePath = Path.GetTempFileName();
            string fileName = CreateGuidFilePath(file);

            if (file.Length > 0)
                using (var fileStream = new FileStream(sourcePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }

            File.Move(sourcePath, fileName);
            return fileName;
        }



        public static IResult Delete(string sourcePath)
        {
            try
            {
                File.Delete(sourcePath);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }
            return new SuccessResult();
        }

        public static string Update(string oldPath, IFormFile file)
        {
            string newPath = CreateGuidFilePath(file);
            if (oldPath.Length > 0)
            {
                using (var fileStream = new FileStream(newPath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
            }

            File.Delete(oldPath);

            return newPath;
        }
    }
}
