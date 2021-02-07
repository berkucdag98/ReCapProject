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
            CarManager carManager = new CarManager(new EfCarDal());

            BrandManager brandManager = new BrandManager(new EfBrandDal());

            ColorManager colorManager = new ColorManager(new EfColorDal());



            //Car carAdd = new Car { BrandId=2,ColorId=5,DailyPrice=500,Description="Efsane",ModelYear=2019};
            //carManager.Add(carAdd);

            //Brand brandAdd = new Brand { BrandName="WV"};
            //brandManager.Add(brandAdd);

            //Car carDelete = new Car { Id=6};

            //carManager.Delete(carDelete);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            foreach (var carColor in carManager.GetAllByColor(2))
            {
                Console.WriteLine(carColor.ModelYear);
            }

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }

        }
    }
}
