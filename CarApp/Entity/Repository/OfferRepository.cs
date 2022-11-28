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

        const int nrOfElementsPerPage = 20;

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

        public async Task<ICollection<Offer>> GetOffersByPage(Offer offer, int page)
        {
            var result = await _context.Set<Offer>().Skip(page * nrOfElementsPerPage).Take(nrOfElementsPerPage)
                .Where(o => 
                (o.Brand == offer.Brand
                || offer.Brand == "")
                &&(o.Model == offer.Model || offer.Model == "")
                &&(o.Engine == offer.Engine || offer.Engine == "")
                &&(o.Extra.Contains(offer.Extra))
                &&(o.Description.Contains(offer.Description))
                ).ToListAsync();

            return result;
        }

        public async Task UpdateOffer(Offer offer)
        {
            await Update(offer);
        }
    }
}
