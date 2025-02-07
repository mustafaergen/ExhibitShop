using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog_Services.Contracts;
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

            var customers = _userManager.Users.ToList();
            int countCustomer = 0;
            foreach (var item in customers)
            {
                var roles = await _userManager.GetRolesAsync(item);
                if(!roles.Any(roles => roles == "Admin"))
                {
                    if (!roles.Any(roles => roles == "Customer"))
                    {
                        countCustomer++;
                    }

                }
            }

            ViewBag.CustomerCount = countCustomer;
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
    }
}
