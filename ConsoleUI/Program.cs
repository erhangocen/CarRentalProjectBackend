using System;
using Business.Concrete;
using DataAccsess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI 
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var car in carManager.GetAll())
            {
                foreach (var color in colorManager.GetByColorId(car.ColorId))
                {
                    foreach (var brand in brandManager.GetByBrandId(car.BrandId))
                    {
                        Console.WriteLine(
                            brand.BrandName +" - "+ color.ColorName +" - "+
                            car.Description);
                        
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
