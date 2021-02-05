using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2020,DailyPrice=100000,Description="200 basıyo" },
                new Car{Id=1,BrandId=2,ColorId=2,ModelYear=2019,DailyPrice=150000,Description="250 basıyo" },
                new Car{Id=1,BrandId=3,ColorId=3,ModelYear=2018,DailyPrice=175000,Description="200 basıyo" },
                new Car{Id=1,BrandId=4,ColorId=4,ModelYear=2017,DailyPrice=180000,Description="180 basıyo" },
                new Car{Id=1,BrandId=5,ColorId=5,ModelYear=2016,DailyPrice=190000,Description="220 basıyo" }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByColor(int colorId)
        {
            return _cars.Where(c=>c.ColorId == colorId).ToList();
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
