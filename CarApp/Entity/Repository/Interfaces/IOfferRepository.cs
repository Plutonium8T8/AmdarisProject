using Entity.Models.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repository.Interfaces
{
    public interface IOfferRepository : IRepository<Offer>
    {
        Task CreateOffer(Offer offer);
        Task<Offer> GetOfferById(long id);
        Task<ICollection<Offer>> GetOffersByPage(Offer offer, int page);
        Task DeleteOffer(long id);
        Task UpdateOffer(Offer offer);
    }
}
