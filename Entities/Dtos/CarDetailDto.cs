﻿using CoreLayer.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CarDetailDto:IDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string ImagePath { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public decimal DailyPrice { get; set; }
        public int ModelYear { get; set; }
    }
}
