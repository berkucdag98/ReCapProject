using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //ColorTest();

            //UserTest();

            //CustomerTest();

            //RentalTest();

            //RentalReturn();


        }

        private static void RentalReturn()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.UpdateReturnDate(7);
            Console.WriteLine(result.Message);

        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rentalAdd = new Rental { CarId = 1, CustomerId = 1, RentDate = DateTime.Now };
            var result = rentalManager.Add(rentalAdd);
            Console.WriteLine(result.Message);
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer customerAdd = new Customer { UserId = 1, CompanyName = "Tesan" };
            var result = customerManager.Add(customerAdd);
            Console.WriteLine(result.Message);

        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User userAdd = new User { FirstName="Berk",LastName="Üçdağ",Email="berkda3@gmail.com",Password="123456"};
            var result = userManager.Add(userAdd);
            Console.WriteLine(result.Message);

        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            if (result.Success == true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //Brand brandAdd = new Brand { BrandName="WV"};
            //brandManager.Add(brandAdd);
            var result = brandManager.GetAll();
            foreach (var brand in result.Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //Car carAdd = new Car { BrandId=2,ColorId=5,DailyPrice=500,Description="Efsane",ModelYear=2019};
            //carManager.Add(carAdd);
            //Car carDelete = new Car { Id=6};
            //carManager.Delete(carDelete);
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.Description + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
            }
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }
            foreach (var car in carManager.GetAllByBrand(2).Data)
            {
                Console.WriteLine(car.DailyPrice);
            }
        }
    }
}
