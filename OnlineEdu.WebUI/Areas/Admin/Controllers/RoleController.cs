using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.RoleDtos;
using OnlineEdu.WebUI.Services.RoleServices;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class RoleController(IRoleService roleService) : Controller
    {

        
        public async Task<IActionResult> Index()
        {
            var values = await roleService.GetAllRolesAsync();
            return View(values);
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto createRoleDto)
        {
            await roleService.CreateRoleAsync(createRoleDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            await roleService.DeleteRoleAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
