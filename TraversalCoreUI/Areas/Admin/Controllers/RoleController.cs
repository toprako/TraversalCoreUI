using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreUI.Areas.Admin.Models;

namespace TraversalCoreUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Role")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [Route("Index")]
        [Route("")]
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        [Route("CreateRole")]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            AppRole role = new()
            {
                Name = model.RoleName,
                Id = Guid.NewGuid(),
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [Route("DeleteRole/{Id}")]
        public async Task<IActionResult> DeleteRole(Guid Id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == Id);
            await _roleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("UpdateRole/{Id}")]
        public IActionResult UpdateRole(Guid Id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == Id);
            return View(new UpdateRoleViewModel()
            {
                RoleId = role.Id,
                RoleName = role.Name,
            });
        }

        [HttpPost]
        [Route("UpdateRole/{Id}")]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel model)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == model.RoleId);
            role.Name = model.RoleName;
            await _roleManager.UpdateAsync(role);
            return RedirectToAction("Index");
        }

        [Route("UserList")]
        public IActionResult UserList()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        [Route("AssignRole/{Id}")]
        [HttpGet]
        public async Task<IActionResult> AssignRole(Guid Id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == Id);
            TempData["userId"] = user.Id;
            if (user == null)
            {
                return View();
            }
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> roleAssignViewModels = new();
            foreach (var role in roles)
            {
                RoleAssignViewModel model = new();
                model.RoleId = role.Id;
                model.RoleName = role.Name;
                model.RoleExist = userRoles.Contains(role.Name);
                roleAssignViewModels.Add(model);
            }
            return View(roleAssignViewModels);
        }

        [HttpPost]
        [Route("AssignRole/{Id}")]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> models)
        {
            var userId = Guid.Parse(TempData["userId"].ToString());
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            foreach (var item in models)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("UserList");
        }
    }
}
