//using System;
//using System.Security.Cryptography.X509Certificates;
//using System.Threading;
//using Business.Concrete;
//using Core.Entities.Concrete;
//using DataAccsess.Concrete.EntityFramework;
//using Entities.Concrete;

//namespace ConsoleUI 
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //CarManager carManager = new CarManager(new EfCarDal());
//            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
//            //UserManager userManager = new UserManager(new EfUserDal());
//            //GetCarDetailTest(carManager);
//            //AddTest(carManager);
//            //UpdateTest(carManager);
//            //DeleteTest(carManager);
//            //GetAllTest(carManager);
//            //GetByIdTest(carManager);
//            //GetRentalDetailTest(rentalManager);
//            //AddRental(rentalManager);

//            //var result = userManager.GetAll();

//            Console.WriteLine("\t FirstName \t|\t LastName \t|\t Email \t\t\t|\t Password");

//            foreach (var user in result.Data)
//            {
                
//                    Console.WriteLine("---------------------------------------------------------------------------------------------------");
//                    Console.WriteLine("\t" + user.FirstName + "\t\t|\t" + user.LastName + "\t\t|\t" + user.Email +
//                                      "\t|\t" + user.PasswordHash);
                
//            }

//            var add = userManager.Add(new User()
//                {FirstName = "Davut", LastName = "Pala", Email = "davutpala@gmail.com"});

//            Console.WriteLine(add.Message);

//            if (add.Success)
//            {
//               foreach (var user in result.Data) 
//               {

//                Console.WriteLine("---------------------------------------------------------------------------------------------------");
//                Console.WriteLine("\t" + user.FirstName + "\t\t|\t" + user.LastName + "\t\t|\t" + user.Email +
//                                  "\t|\t" + user.PasswordHash);

//               } 
//            }
            

//            Console.ReadLine();
//        }

//        private static void AddRental(RentalManager rentalManager)
//        {
//            var result = rentalManager.Add(new Rental(){CarId = 1, CustomerId = 2});
//        }

//        //private static void GetRentalDetailTest(RentalManager rentalManager)
//        //{
//        //    var result = rentalManager.GetFullRentalDetail();

//        //    Console.WriteLine("\t RentedCar \t|\t Customer \t|\t RentDate \t|\t ReturnDate");

//        //    foreach (var rentedCar in result.Data)
//        //    {
//        //        Console.WriteLine("---------------------------------------------------------------------------------------------");
//        //        Console.WriteLine("\t" + rentedCar.Car + "\t|\t" + rentedCar.CustomerName + "\t|\t" + rentedCar.RentDate +
//        //                          "\t|\t" + rentedCar.ReturnDate);
//        //    }

//        //    Console.WriteLine("\n" + result.Message);
//        //}

//        private static void GetByIdTest(CarManager carManager)
//        {
//            var result = carManager.GetById(2);
//            Console.WriteLine(result.Message);
//            Console.WriteLine(result.Data.Description);
//        }

//        private static void GetAllTest(CarManager carManager)
//        {
//            var result = carManager.GetAll();


//            Console.WriteLine(result.Message + ".");
//            Thread.Sleep(750);
//            Console.Clear();

//            Console.WriteLine(result.Message + "..");
//            Thread.Sleep(750);
//            Console.Clear();

//            Console.WriteLine(result.Message + "...");
//            Thread.Sleep(750);
//            Console.Clear();

//            foreach (var car in result.Data)
//            {
//                Console.WriteLine(car.CarId + " - " + car.BrandId + " - " + car.ColorId + " - " + car.DailyPrice + " - " +
//                                  car.Description + " - " + car.ModelYear);
//            }
//        }

//        private static void DeleteTest(CarManager carManager)
//        {
//            var result = carManager.Delete(new Car() {CarId = 1006});
//            Console.WriteLine(result.Message);
//        }

//        private static void UpdateTest(CarManager carManager)
//        {
//            var result = carManager.Update(new Car()
//                {CarId = 1, ColorId = 6, ModelYear = 2005, DailyPrice = 19, Description = "Classic", BrandId = 1});
//            Console.WriteLine(result.Message);

//        }

//        private static void AddTest(CarManager carManager)
//        {
//            var result = carManager.Add(new Car()
//            {
//                BrandId = 1, ColorId = 4, DailyPrice = 12, Description = "Slow", ModelYear = 2007
//            });
//            Console.WriteLine(result.Message);
//        }

//        private static void GetCarDetailTest(CarManager carManager)
//        {
//            var result = carManager.GetCarDetails();
//            if (result.Success)
//            {
//                Console.WriteLine("\t Brand \t|\t Color \t|\t Price \t\t|\t Model \t\t|\t Description");

//                foreach (var car in result.Data)
//                {
//                    Console.WriteLine("------------------------------------------------------------------------------------------------------------");
//                    Console.WriteLine("\t" + car.BrandName + "\t|\t" + car.ColorName + "\t|\t" + car.DailyPrice +
//                                      " (daily)\t|\t" + car.ModelYear + " model\t|\t" + car.CarName);
//                }

//                Console.WriteLine("\n" + result.Message);
//            }
//            else
//            {
//                Console.WriteLine(result.Message);
//            }
//        }
//    }
//}
