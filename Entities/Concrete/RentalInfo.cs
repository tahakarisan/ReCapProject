﻿using CoreLayer.Entities;
using System;

namespace Entities.Concrete
{
    public class RentalInfo: BaseEntity
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }    
}
