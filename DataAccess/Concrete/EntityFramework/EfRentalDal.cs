using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public void UpdateReturnDate(int rentalId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = context.Rentals.Where(x => x.Id == rentalId).First();
                result.ReturnDate = DateTime.Now;
                context.SaveChanges();
            }
        }
    }
}
