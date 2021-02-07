using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _iCarDal;

        public CarManager(ICarDal iCarDal)
        {
            _iCarDal = iCarDal;
        }

        public void Add(Car entity)
        {
            if (entity.Description.Length > 2)
            {
                if (entity.DailyPrice > 0)
                {
                    _iCarDal.Add(entity);
                }
                else
                {
                    Console.WriteLine("Günlük fiyat 0'dan büyük olmalıdır.");
                }
            }
            else
            {
                Console.WriteLine("Araba ismi minimum 2 karakter olmalıdır");
            }
        }

        public void Delete(Car entity)
        {
            _iCarDal.Delete(entity);
        }

        public List<Car> GetAll()
        {
            return _iCarDal.GetAll();
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _iCarDal.GetAll(p => p.BrandId == brandId);
        }

        public List<Car> GetAllByColor(int colorId)
        {
            return _iCarDal.GetAll(p => p.ColorId == colorId);
        }

        public void Update(Car entity)
        {
            _iCarDal.Update(entity);
        }
    }
}
