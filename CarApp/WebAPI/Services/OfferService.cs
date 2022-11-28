using AutoMapper;
using Others.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.DataTransferObject.Offer;
using WebAPI.Services.Interfaces;
using Entity.Models.Offers;
using Entity.Repository.Interfaces;

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

            await _offersRepository.CreateOffer(offer);
        }

        public async Task DeleteOffer(long id)
        {
            var result = await _offersRepository.GetOfferById(id);

            if (result == null) throw new EntityNotFoundException("", "Offer does not exist!");

            await _offersRepository.DeleteOffer(id);
        }

        public async Task<OfferResoponseDTO> GetOffer(long id)
        {
            var result = await _offersRepository.GetOfferById(id);

            if (result == null) throw new EntityNotFoundException("", "Offer does not exist!");

            var output = _mapper.Map<OfferResoponseDTO>(result);

            return output;
        }

        public async Task<ICollection<OfferResoponseDTO>> GetOffersByPage(OfferCreateDTO offerResponse, int page)
        {
            var offer = _mapper.Map<Offer>(offerResponse);

            var result = await _offersRepository.GetOffersByPage(offer, page);

            if (result == null) throw new EntityNotFoundException("", "Offer does not exist!");

            var output = _mapper.Map<ICollection<OfferResoponseDTO>>(result);

            return output;
        }

        public async Task UpdateOffer(OfferUpdateDTO offerUpdate)
        {
            // To Do structura ca la User Service

            var response = await _offersRepository.GetOfferById(offerUpdate.Id);

            if (response == null) throw new EntityNotFoundException("", "Offer does not exist!");

            await _offersRepository.UpdateOffer(response);
        }
    }
}
