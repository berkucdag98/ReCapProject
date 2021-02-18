using Business.Abstract;
using Business.Constants;
using Core.Ultities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Car entity)
        {
            if (entity.Description.Length > 2)
            {
                if (entity.DailyPrice > 0)
                {
                    _iCarDal.Add(entity);
                    return new SuccessResult(Messages.Added);
                }
                else
                {
                    //Console.WriteLine("Günlük fiyat 0'dan büyük olmalıdır.");
                    return new SuccessResult(Messages.Failed);
                }
            }
            else
            {
                //Console.WriteLine("Araba ismi minimum 2 karakter olmalıdır");
                return new SuccessResult(Messages.Failed);
            }
        }

        public IResult Delete(Car entity)
        {
            _iCarDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(),Messages.Listed);
        }

        public IDataResult<List<Car>> GetAllByBrand(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetAllByColor(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.ColorId == colorId));
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_iCarDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails());
        }

        public IResult Update(Car entity)
        {
            _iCarDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }
    }
}
