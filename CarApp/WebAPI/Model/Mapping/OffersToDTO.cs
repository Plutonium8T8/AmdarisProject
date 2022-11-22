using AutoMapper;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.DataTransferObject.Offers;

namespace WebAPI.Model.Mapping
{
    public class OffersToDTO : Profile
    {
        public OffersToDTO()
        {
            CreateMap<OfferCreateDTO, Offer>();

            CreateMap<Offer, OfferResoponseDTO>();
        }
    }
}