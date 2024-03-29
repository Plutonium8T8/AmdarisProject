﻿using WebAPI.Model.DataTransferObject.Offer;

namespace WebAPI.Services.Interfaces
{
    public interface IOffersService
    {
        Task<OfferResoponseDTO> GetOffer(long id);
        Task<ICollection<OfferResoponseDTO>> GetOffersByPage(OfferCreateDTO offerResponse, int id);
        Task DeleteOffer(long id);
        Task UpdateOffer(OfferUpdateDTO offerUpdate);
        Task CreateOffer(OfferCreateDTO offerCreate);
    }
}
