using AutoMapper;
using Others.Exceptions;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.DataTransferObject.Offer;
using WebAPI.Services.Interfaces;
using Entity;

namespace WebAPI.Services
{
    public class OfferService : IOffersService
    {
        private IOfferRepository _offersRepository { get; }
        private IMapper _mapper { get; }
        public OfferService(IOfferRepository offersRepository, IMapper mapper)
        {
            _offersRepository = offersRepository;
            _mapper = mapper;
        }

        public async Task CreateOffer(OfferCreateDTO offerCreate)
        {
            var offer = _mapper.Map<Offer>(offerCreate);
            var result = await _offersRepository.CreateOffer(offer);
        }
    }
}
