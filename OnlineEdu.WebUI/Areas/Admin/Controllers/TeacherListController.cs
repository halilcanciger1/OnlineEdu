﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TeacherListController(UserManager<AppUser> userManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await userManager.GetUsersInRoleAsync("Teacher");
            return View(values);
        }
    }
}
