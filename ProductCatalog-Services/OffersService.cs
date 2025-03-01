using ProductCatalog_Repositories.Contracts;
using ProductCatalog_Repositories.UnitOfWork;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Services
{
    public class OffersService : IOffersService
    {
        private readonly IRepositoryManager _manager;

        public OffersService(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateOffers(Offers offers)
        {
            _manager.OffersRepository.Create(offers);
            _manager.Save();
        }

        public void DeleteOffers(int id)
        {
            var off = _manager.OffersRepository.FindById(id);
            if (off == null)
            {
                throw new Exception("Offers is not found");
            }
            _manager.OffersRepository.Delete(off);
            _manager.Save();
        }

        public IEnumerable<Offers> GetOffers()
        {
            return _manager.OffersRepository.FindAll().ToList();
        }

        public Offers GetOffersById(int id)
        {
            var off = _manager.OffersRepository.FindById(id);
            if(off is null)
            {
                throw new Exception("Offers is not found");
            }

            return off;
        }

        public void UpdateOffers(Offers offers)
        {
            var existingOffers = _manager.OffersRepository.FindById(offers.Id);
            if (existingOffers is null)
                throw new Exception("Offers not found");
            
            existingOffers.OfferPrice = offers.OfferPrice;
            existingOffers.CounterPrice = offers.CounterPrice;
            existingOffers.Status = offers.Status;
        }
    }
}
