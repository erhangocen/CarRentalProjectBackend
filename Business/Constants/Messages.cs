using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "New Car Added";
        public static string CarYearInvalid = "This car is very old";
        public static string SearchCar = "The car you were looking for was found";
        public static string CarListed = "All cars is listing ";
        public static string CarListedByBrand = "Seçtiğiniz marka araçlar listelendi";
        public static string CarListedByColor = "Seçtiğiniz renkteki araçlar listelendi";
        public static string CarListedByDetail = "Araçlar tüm özellikleri ile listelendi";
        public static string ErrorDataResult = "Sistem 16.00 ile 17.00 arası bakımdadır";
        public static string CarUpdate = "Datas updated";
        public static string CarDelete = "This car deleted";
        public static string RentedCarList = "Kiralanan araçlar listelendi";
        public static string NameInvalid = "Invalid Name";
        public static string SurnameInvalid = "Invalid Surname";
        public static string PasswordInvalid = "Invalid Password";
        public static string EmailInvalid = "Invalid email";
        public static string EmailInvalid2 = "This email has already used";
        public static string SuccessCreateAccount = "Your account successfully created";
        public static string SuccessUpdateAccount = "Your datas updated";
        public static string SuccessDeleteAccount = "Your account deleted";
        public static string ErrorDataAccsess = "An error has occurred in data access";
        public static string ErrorUpdate = "An error has occurred in data updating";
        public static string ErrorDelete = "An error has occurred in data deleting";
        public static string ErrorAdd = "Error while adding data";
        public static string RentUpdate = "Rent datas updated";
        public static string RentDelete = "Rent datas deleted";
        public static string BrandAdd = "Brand added";
        public static string BrandUpdate = "Brand updated";
        public static string BrandDelete = "Brand deleted";
        public static string ColorAdd = "Color added";
        public static string ColorUpdate = "Color updated";
        public static string ColorDelete = "Color deleted";
        public static string AddCarImage = "Car image added";
        public static string UpdateCarImage = "Araç resmi güncellendi";
        public static string DeleteCarImage = "Araç resmi Silindi";
        public static string ImagesisFull = "More than 5 images cannot be added to a car";
        public static string UserNotFound = "This user is undefinded";
        public static string WrongPassword = "Wrong Password";
        public static string SuccesLogin = "You successfully entered";
        public static string UserAlredyExist = "This user already exist";
        public static string SuccesRegister = "Your account has been successfully created";
        public static string AccsessTokenCreated = "AccessToken oluşturuldu";
        public static string AuthorizationDenied = "Buna Yetkiniz Yok";
        public static string PPSuccesfullUpdate = "Profile fotoğrefınız Güncellendi";
        public static string PPDelete = "Profil fotoğrafı kaldırıldı";
        public static string AddClaim = "Yetki Eklendi";
        public static string updateClaim = "Yetki Güncellendi";
        public static string DeleteClaim = "Yetki Siindi";
        public static string SuccesUpdateUser = "Bilgileriniz güncellendi";
        public static string NotEnoughFindex = "Your findex point isn't enough for this car";
        public static string RentalNotAvailable = "Rental is not available";
        public static string RentalDateOk = "Successful";
        public static string RentalReturnDateError = "The vehicle was rented by someone else between the selected dates";
        public static string CVCrror = "CVC consists of 3 or 4 characters";
        public static string CardNumberError = "Card Number consist of 16 characters";
        public static string CardNumberiswrong = "Card Number must be 16 digits";
        public static string ExpMonthisWrong = "There are 12 months in a year";
        public static string Expired = "This card has expired";
        public static string WrongCvc = "CVC must be 3 or 4 digits";
        public static string AddRental = "Feel happy while using it";
        public static string SendMessage = "Your Message Has Been Sent";
        public static string deleteMessage = "Message Has Been Deleted";
    }
}