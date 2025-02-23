using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Models;

namespace ProductCatalog_Web.Areas.CustomerRelations.Controllers
{
    [Area("CustomerRelations")]
    [Authorize(Roles= "CustomerRelations")]
    public class QuestionController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public QuestionController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            return View(_serviceManager.QuestionsService.GetQuestions());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Questions question)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.QuestionsService.CreateQuestions(question);
                return RedirectToAction("Index");
            }
            return View(question);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_serviceManager.QuestionsService.GetQuestionsById(id));
        }
        [HttpPost]
        public IActionResult Edit(Questions question)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.QuestionsService.UpdateQuestions(question);
                return RedirectToAction("Index");
            }
            return View(question);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_serviceManager.QuestionsService.GetQuestionsById(id));
        }
    }
}
