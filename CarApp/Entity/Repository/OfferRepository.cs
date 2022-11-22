using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity
{
    public class OfferRepository : GenericRepository<Offer>, IOfferRepository
    {
        public OfferRepository(AppContext context) : base(context)
        {

        }

        public async Task<Offer> CreateOffer(Offer offer)
        {
            await base.Create(offer);

            return offer;
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

        public async Task<Offer> UpdateOffer(Offer offer)
        {
            await base.Update(offer);

            return offer;
        }
    }
}
