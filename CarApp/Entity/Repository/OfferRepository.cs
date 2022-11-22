using Entity.Models.Offers;
using Entity.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;

namespace Entity.Repository
{
    public class OfferRepository : GenericRepository<Offer>, IOfferRepository
    {
        public OfferRepository(AppContext context) : base(context)
        {

        }

        public async Task CreateOffer(Offer offer)
        {
            await Create(offer);
        }

        public async Task DeleteOffer(long id)
        {
            var result = await _context.Set<Offer>().FirstOrDefaultAsync(o => o.Id == id);

            await Delete(result);
        }

        public async Task<Offer> GetOfferById(long id)
        {
            var result = await _context.Set<Offer>().FirstOrDefaultAsync(o => o.Id == id);

            return result;
        }

        public async Task UpdateOffer(Offer offer)
        {
            await Update(offer);
        }
    }
}
