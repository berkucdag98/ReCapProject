using Core.Ultities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService:IBaseService<Car>
    {
        IDataResult<List<Car>> GetAllByBrand(int brandId);

        IDataResult<List<Car>> GetAllByColor(int colorId);

        IDataResult<List<CarDetailDto>> GetCarDetails();

    }
}
