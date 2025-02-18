﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.RoleDtos;
using OnlineEdu.WebUI.DTOs.UserDtos;

namespace OnlineEdu.WebUI.Services.UserServices
{
    public class UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper mapper) : IUserService
    {


        public Task<bool> AssignRoleAsync(List<AssignRoleDto> assignRoleDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateRoleAsync(UserRoleDto userRoleDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto)
        {
            var user = new AppUser
            {
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email
            };

            if(userRegisterDto.Password != userRegisterDto.ConfirmPassword)
            {
                return new IdentityResult();
            }

            var result = await userManager.CreateAsync(user, userRegisterDto.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Student");
            }
            return result;
        }

        public async Task<List<ResultTeacherDto>> Get4TeachersAsync()
        {
            var teacherList = await userManager.GetUsersInRoleAsync("Teacher");
            var values = teacherList.Take(4).ToList();
            return mapper.Map<List<ResultTeacherDto>>(values);
        }

        public async Task<List<AppUser>> GetAllUsersAsync()
        {
            return await userManager.Users.ToListAsync();
        }

        public async Task<AppUser> GetIdByUserAsync(int id)
        {
            return await userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<string> LoginAsync(UserLoginDto userLoginDto)
        {
            var user = await userManager.FindByEmailAsync(userLoginDto.Email);

            if (user == null)
            {
                return null;
            }

            var result = await signInManager.PasswordSignInAsync(user, userLoginDto.Password, false, false);

            if (!result.Succeeded)
            {
                return null;
            }

            else
            {
                var IsAdmin = await userManager.IsInRoleAsync(user, "Admin");
                if (IsAdmin) { return "Admin"; };

                var IsTeacher = await userManager.IsInRoleAsync(user, "Teacher");
                if (IsTeacher) { return "Teacher"; };

                var IsStudent = await userManager.IsInRoleAsync(user, "Student");
                if (IsStudent) { return "Student"; };
            }

            return null;

        }

        public Task<bool> LogoutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
