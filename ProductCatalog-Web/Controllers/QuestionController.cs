using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Enums;
using ProductCatolog_Core.Models;

namespace ProductCatalog_Web.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public QuestionController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            var userId = _serviceManager.UserManager.GetUserAsync(User).Result.Id;
            return View(_serviceManager.QuestionsService.GetQuestionsByUserId(userId));
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.QuestionTypes = new SelectList(_serviceManager.QuestionTypeService.GetQuestionTypes(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Questions model)
        {
            if (ModelState.IsValid)
            {
                model.Status = Status.Active;
                _serviceManager.QuestionsService.CreateQuestions(model);
                return RedirectToAction("Index");
            }

            ViewBag.QuestionTypes = new SelectList(_serviceManager.QuestionTypeService.GetQuestionTypes(), "Id", "Name");
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var question = _serviceManager.QuestionsService.GetQuestionsById(id);
            ViewBag.QuestionTypes = new SelectList(_serviceManager.QuestionTypeService.GetQuestionTypes(), "Id", "Name");
            return View(question);
        }
        [HttpPost]
        public IActionResult Edit(Questions model)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.QuestionsService.UpdateQuestions(model);
                return RedirectToAction("Index");
            }

            ViewBag.QuestionTypes = new SelectList(_serviceManager.QuestionTypeService.GetQuestionTypes(), "Id", "Name");
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _serviceManager.QuestionsService.DeleteQuestions(id);
            return RedirectToAction("Index");
        }
    }
}
