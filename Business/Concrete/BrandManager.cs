﻿using Business.Abstract;
using Business.Constant;
using CoreLayer.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName == null)
            {
                return new ErrorResult("Marka Adı boş bırakılamaz");
            }
            _brandDal.Add(brand);
            return new SuccesfullResult("Marka başarıyla eklendi");
        }

        public IResult Delete(int id)
        {
            if (!_brandDal.GetAll(b=>b.BrandId==id).Any())
            {
                return new ErrorResult("Zaten böyle bir veri bulunmuyor");
            }
            _brandDal.Delete(id);
            return new SuccesfullResult("Marka başarıyla silindi");
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 3 || DateTime.Now.Hour == 6)
            {
                return new DataErrorResult<List<Brand>>(Messages.ListInMaintenance);
            }
            return new DataSuccesfullResult<List<Brand>>(_brandDal.GetAll(),"Markalar listelendi");
        }

        public IDataResult<List<Brand>> GetById(int id)
        {
            if (DateTime.Now.Hour == 3 || DateTime.Now.Hour == 6)
            {
                return new DataErrorResult<List<Brand>>(Messages.ListInMaintenance);
            }
            return new DataSuccesfullResult<List<Brand>>(_brandDal.GetAll(b=>b.BrandId==id));
        }


        public IResult Update(Brand brand)
        {
            if (!_brandDal.GetAll(b => b.BrandId == brand.BrandId).Any())
            {
                return new ErrorResult("Zaten böyle bir veri bulunmuyor");
            }
            _brandDal.Update(brand);
            return new SuccesfullResult("Marka başarıyla güncellendi");
        }
    }
}