using Business.Concrete;
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
            CarTest();
            //BrandTest();
            //ColorTest();

        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //Brand brandAdd = new Brand { BrandName="WV"};
            //brandManager.Add(brandAdd);
            foreach (var brand in brandManager.GetAll())
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
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.Description + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
            }
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            foreach (var car in carManager.GetAllByBrand(2))
            {
                Console.WriteLine(car.DailyPrice);
            }
        }
    }
}
