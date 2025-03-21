﻿using Microsoft.AspNetCore.Mvc;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Models;

namespace ProductCatalog_Web.Controllers
{
    public class OffersController : Controller
    {
        private readonly IServiceManager _serviceManager;
        public OffersController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _serviceManager.UserManager.GetUserAsync(User);
            if (user is null)
                return RedirectToAction("Login","Account");
            else
            {
                var off = _serviceManager.OffersService.GetOffers();
                ViewBag.OffersCount = off.Count();
                return View(off);
            }
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            var product = _serviceManager.ProductService.GetProduct(id);
            return View();
        }
        [HttpPost]
        public IActionResult Create(Offers offer)
        {
            //if(offer.UserId is null && offer.Product is null)
            //{
            //    offer.UserId = ;
            //    offer.Product = ViewBag.Product;
            //}
            _serviceManager.OffersService.CreateOffers(offer);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_serviceManager.OffersService.GetOffersById(id));
        }
        [HttpPost]
        public IActionResult Edit(Offers offers)
        {
            if (offers is null)
                return NoContent();

            _serviceManager.OffersService.UpdateOffers(offers);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _serviceManager.OffersService.DeleteOffers(id);
            return RedirectToAction("Index");
        }
    }
}
