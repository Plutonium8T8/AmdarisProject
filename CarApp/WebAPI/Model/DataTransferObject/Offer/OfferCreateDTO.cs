using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model.DataTransferObject.Offer
{
    public class OfferCreateDTO
    {
        public long UserId { get; set; }
        public string Name { get; set; }
    }
}