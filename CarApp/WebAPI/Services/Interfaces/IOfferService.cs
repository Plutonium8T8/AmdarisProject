using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.DataTransferObject;
using WebAPI.Model.DataTransferObject.Offer;

namespace WebAPI.Services.Interfaces
{
    public interface IProjectService
    {
        Task<OfferResoponseDTO> GetProject(long id);
        Task DeleteProject(long id);
        Task UpdateProject(OfferUpdateDTO projectUpdate);
        Task CreateProject(OfferCreateDTO projectCreate);
    }
}