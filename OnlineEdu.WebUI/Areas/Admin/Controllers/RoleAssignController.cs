﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.UserDtos;
using OnlineEdu.WebUI.Models;
using OnlineEdu.WebUI.Services.UserServices;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]

    public class RoleAssignController(IUserService userService, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await userService.GetAllUsersAsync();
            
            var userList = (from user in values
                            select new UserViewModel
                            {
                                Id = user.Id,
                                NameSurname = user.FirstName + " " + user.LastName,
                                UserName = user.UserName,
                                Roles = userManager.GetRolesAsync(user).Result.ToList()
                            }).ToList();
            return View(userList);
        }


        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = await userService.GetIdByUserAsync(id);

            TempData["userId"] = user.Id;

            var roles = await roleManager.Roles.ToListAsync();

            var userRoles = await userManager.GetRolesAsync(user);

            List<AssignRoleDto> assignRoleList = new List<AssignRoleDto>();

            foreach (var role in roles) 
            {
                AssignRoleDto assignRole = new AssignRoleDto();
                {
                    assignRole.RoleId = role.Id;
                    assignRole.RoleName = role.Name;
                    assignRole.RoleExist = userRoles.Contains(role.Name);
                };
                assignRoleList.Add(assignRole);
            }

            return View(assignRoleList);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDto> assignRoleDto)
        {
            var userId = (int)TempData["userId"];
            var user = await userService.GetIdByUserAsync(userId);
            foreach (var item in assignRoleDto)
            {
                if (item.RoleExist)
                {
                    await userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
