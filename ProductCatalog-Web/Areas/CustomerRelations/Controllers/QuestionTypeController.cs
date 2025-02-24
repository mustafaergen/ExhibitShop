using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Models;

namespace ProductCatalog_Web.Areas.CustomerRelations.Controllers
{
    [Area("CustomerRelations")]
    [Authorize(Roles= "CustomerRelations")]
    public class QuestionTypeController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public QuestionTypeController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            return View(_serviceManager.QuestionTypeService.GetQuestionTypes());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(QuestionType questionType)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.QuestionTypeService.CreateQuestionType(questionType);
                return RedirectToAction("Index");
            }
            return View(questionType);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var questionType = _serviceManager.QuestionTypeService.GetQuestionTypeById(id);
            if (questionType == null)
                return NotFound();
            else
            {
                _serviceManager.QuestionTypeService.DeleteQuestionType(id);
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_serviceManager.QuestionTypeService.GetQuestionTypeById(id));
        }


        [HttpPost]
        public IActionResult Edit(QuestionType questionType)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.QuestionTypeService.UpdateQuestionType(questionType);
                return RedirectToAction("Index");
            }
            return View(questionType);
        }
    }
}
