using ProductCatolog_Core.DTOs;
using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Services.Contracts
{
    public interface IOffersService
    {
        IEnumerable<Offers> GetOffers();
        Offers GetOffersById(int id);
        void CreateOffers(Offers offers);
        void UpdateOffers(Offers offers);
        void DeleteOffers(int id);
    }
}
