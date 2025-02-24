using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.DTOs;
using ProductCatolog_Core.Enums;
using ProductCatolog_Core.Models;
using ProductCatolog_Core.VMs;

namespace ProductCatalog_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly UserManager<Customer> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IServiceManager _serviceManager;

        public HomeController(UserManager<Customer> userManager, RoleManager<IdentityRole> roleManager, IServiceManager serviceManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _serviceManager = serviceManager;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.UserCount = _userManager.Users.Count();
            ViewBag.ProductCount = GetProductsCount().Count();
            ViewBag.CategoryCount = GetCategoriesCount().Count();
            ViewBag.OrderCount = GetOrderCountList().Count();
            ViewBag.ArticleCount = GetArticlesCount().Count();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RoleManager(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            var allRoles = _roleManager.Roles.Select(r => r.Name).ToList();
            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new ManagerUserRoleVM
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = allRoles.Select(role => new RoleSelectionVM
                {
                    RoleName = role,
                    IsSelected = userRoles.Contains(role)
                }).ToList()
            };

            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> RoleManager(ManagerUserRoleVM model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in model.Roles.Where(r=>r.IsSelected && !userRoles.Contains(r.RoleName)))
            {
                await _userManager.AddToRoleAsync(user, role.RoleName);
            }
            foreach (var role in model.Roles.Where(r=>!r.IsSelected && userRoles.Contains(r.RoleName)))
            {
                await _userManager.RemoveFromRoleAsync(user, role.RoleName);
            }
            return RedirectToAction("GetCustomers");
        }


        public async Task<IActionResult> GetCustomers()
        {
            var users = _userManager.Users.ToList();
            var userRoles = new List<UserVM>();
            foreach (var item in users)
            {
                var roles = await _userManager.GetRolesAsync(item);
                userRoles.Add(new UserVM
                {
                    Id=item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    UserName=item.UserName,
                    Roles = roles.ToList()

                });
            }
            return View(userRoles);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound(); 
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("GetCustomers");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View();
        }
        private SelectList GetProductsCount()
        {
            return new SelectList(_serviceManager.ProductService.GetAllProducts(), "Id", "Name");
        }
        private SelectList GetCategoriesCount()
        {
            return new SelectList(_serviceManager.CategoryService.GetCategories(), "Id", "Name");
        }
        private SelectList GetOrderCountList()
        {
            return new SelectList(_serviceManager.OrderService.GettAllOrders(),"Id","Name");
        }
        private SelectList GetArticlesCount()
        {
            return new SelectList(_serviceManager.ArticlesService.GetAllArticle(), "Id", "Name");
        }
        
    }
}
