using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductCatalog_Services.Contracts;

public class CustomerSupportController : Controller
{
    private readonly IServiceManager _serviceManager;

    public CustomerSupportController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public IActionResult Index(int id = 0)
    {
        ViewBag.QuestionType = GetQuestionTypes();

        var questions = id == 0
            ? _serviceManager.QuestionsService.GetQuestions() 
            : _serviceManager.QuestionsService.GetQuestionsByType(id); 

        return View(questions);
    }

    private SelectList GetQuestionTypes()
    {
        var questionTypes = _serviceManager.QuestionTypeService.GetQuestionTypes();
        return new SelectList(questionTypes, "Id", "Name");
    }
}
