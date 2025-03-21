using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Enums;

namespace ProductCatalog_Web.Areas.CustomerRelations.Controllers
{
    [Area("CustomerRelations")]
    [Authorize(Roles = "CustomerRelations")]
    public class HomeController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public HomeController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<IActionResult> Index()
        {
            var orderActivities = await _serviceManager.ActivityService.GetActivitiesByStatus(ActivityStatus.OrderActivity);
            var userActivities = await _serviceManager.ActivityService.GetActivitiesByStatus(ActivityStatus.UserActivity);

            if (orderActivities == null)
            {
                ViewBag.OrderActivityError = "No order activities found.";
            }
            if (userActivities == null)
            {
                ViewBag.UserActivityError = "No user activities found.";
            }

            ViewBag.UserCount = await _serviceManager.UserManager.Users.CountAsync();
            ViewBag.OrderActivity = orderActivities;
            ViewBag.UserActivity = userActivities;
            ViewBag.QuestionCount = _serviceManager.QuestionsService.GetQuestions().Count();
            ViewBag.TotalEarnings = await _serviceManager.OrderService.CalculateTotalEarningsAsync();

            return View();
        }


    }

}
