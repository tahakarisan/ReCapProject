﻿using CoreLayer.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFColorDal : EFEntityRepositoryBase<Color, RentCarContext>, IColorDal
    {
  
    }
}
