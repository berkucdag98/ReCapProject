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

        public List<Car> GetAll()
        {
            return _iCarDal.GetAll();
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _iCarDal.GetAllByBrand(brandId);
        }

        public List<Car> GetAllByColor(int colorId)
        {
            return _iCarDal.GetAllByColor(colorId);
        }
    }
}
