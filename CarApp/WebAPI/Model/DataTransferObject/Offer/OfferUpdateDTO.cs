﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model.DataTransferObject.Offer
{
    public class OfferUpdateDTO
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
    }
}