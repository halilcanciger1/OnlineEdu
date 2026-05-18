using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.RoleDtos;

namespace OnlineEdu.WebUI.Services.RoleServices
{
    public class RoleService(RoleManager<AppRole> roleManager, IMapper mapper) : IRoleService
    {
        public Task CreateRoleAsync(CreateRoleDto createRoleDto)
        {
            var role = mapper.Map<AppRole>(createRoleDto);
            return roleManager.CreateAsync(role);
        }

        public async Task DeleteRoleAsync(int id)
        {
            var value = await roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            await roleManager.DeleteAsync(value);
        }

        public async Task<List<ResultRoleDto>> GetAllRolesAsync()
        {
            var roles = await roleManager.Roles.ToListAsync();
            return mapper.Map<List<ResultRoleDto>>(roles);
        }

        public async Task<UpdateRoleDto> GetRoleByIdAsync(int id)
        {
            var value = await roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<UpdateRoleDto>(value);
        }

       
    }
}
