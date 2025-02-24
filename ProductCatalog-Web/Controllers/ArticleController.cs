﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Enums;
using ProductCatolog_Core.Models;
using System.Drawing;

namespace ProductCatalog_Web.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IServiceManager _serviceManager;
        public ArticlesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index(Status? status)
        {
            var art = _serviceManager.ArticlesService.GetAllArticle();
            if (status.HasValue)
                art = art.Where(a => a.Status == status.Value).ToList();
            ViewBag.ArticleCount = art.Count();
            return View(art);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var art = _serviceManager.ArticlesService.GetArticle(id);
            if(art is null)
                return NotFound();

            return View(art);
        }
    }
}
