using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public interface IOfferRepository : IRepository<Offer>
    {
        Task<Offer> CreateOffer(Offer offer);
        Task<Offer> GetOfferById(long id);
        Task<Offer> DeleteOffer(long id);
        Task<Offer> UpdateOffer(Offer offer);
    }
}
