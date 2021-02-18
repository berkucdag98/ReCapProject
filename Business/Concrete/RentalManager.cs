using Business.Abstract;
using Business.Constants;
using Core.Ultities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental entity)
        {
            var result = _rentalDal.GetAll(x=>x.CarId == entity.CarId && x.ReturnDate == null);
            if (result.Count > 0)
            {
                return new ErrorResult(Messages.Failed);
            }
            _rentalDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(x=>x.Id == id), Messages.Listed);
        }

        public IResult Update(Rental entity)
        {
            var result = _rentalDal.GetAll(x => x.CarId == entity.CarId && x.ReturnDate == null);
            if (result.Count > 0)
            {
                return new ErrorResult(Messages.Failed);
            }
            _rentalDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }

        public IResult UpdateReturnDate(int rentalId)
        {

            _rentalDal.UpdateReturnDate(rentalId);
            return new SuccessResult(Messages.Updated);
        }
    }
}
