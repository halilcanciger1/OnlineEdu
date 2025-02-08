using Microsoft.AspNetCore.Identity;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.UserDtos;

namespace OnlineEdu.WebUI.Services.UserServices
{
    public class UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager) : IUserService
    {


        public Task<bool> AssignRoleAsync(AssignRoleDto assignRoleDto)
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

            return await userManager.CreateAsync(user, userRegisterDto.Password);
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
