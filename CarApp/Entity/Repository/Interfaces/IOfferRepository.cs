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
        Task CreateOffer(Offer offer);
    }
}
