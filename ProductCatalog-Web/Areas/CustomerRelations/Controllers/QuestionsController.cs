using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Enums;
using ProductCatolog_Core.Models;

namespace ProductCatalog_Web.Areas.CustomerRelations.Controllers
{
    [Area("CustomerRelations")]
    [Authorize(Roles = "CustomerRelations")]
    public class QuestionsController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public QuestionsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            var question = _serviceManager.QuestionsService.GetQuestions();
            return View(question);
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
            var userId = _serviceManager.UserManager.GetUserId(User);
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Customer"))
                {
                    model.QuestionStatus = QuestionStatus.Customer;
                }
                else if (User.IsInRole("CustomerRelations"))
                {
                    model.QuestionStatus = QuestionStatus.CustomerRelations;
                }

                model.UserId = userId;
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
