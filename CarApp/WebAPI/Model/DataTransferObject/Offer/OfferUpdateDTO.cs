using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model.DataTransferObject.Offer
{
    public class OfferUpdateDTO
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Price { get; set; }
        public string? Location { get; set; }
        public string? Engine { get; set; }
        public string? Description { get; set; }
        public string? Extra { get; set; }
        public virtual long UserId { get; set; }
    }
}