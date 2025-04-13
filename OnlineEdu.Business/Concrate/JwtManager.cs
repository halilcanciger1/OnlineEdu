using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Business.Configurations;
using OnlineEdu.DTO.DTOs.LoginDtos;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Business.Concrate
{
    public class JwtManager : IJwtService
    {
        private readonly JwtTokenOptions _jwtTokenOptions;
        private readonly UserManager<AppUser> _userManager;

        public JwtManager(IOptions<JwtTokenOptions> jwtTokenOptions, UserManager<AppUser> userManager)
        {
            _jwtTokenOptions = jwtTokenOptions.Value;
            _userManager = userManager;
        }

        public async Task<LoginResponseDto> CreateTokenAsync(AppUser appUser)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenOptions.Key));

            var userRoles = await _userManager.GetRolesAsync(appUser);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()),
                new Claim(ClaimTypes.Email, appUser.Email),
                new Claim(ClaimTypes.Name, appUser.UserName),
                new Claim("fullName", appUser.FirstName + " " + appUser.LastName)

            };

            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtTokenOptions.Issuer,
                audience: _jwtTokenOptions.Audience,
                expires: DateTime.UtcNow.AddMinutes(_jwtTokenOptions.ExpireInMinutes),
                notBefore: DateTime.UtcNow,
                claims: claims,
                signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
            );

            var handler = new JwtSecurityTokenHandler();
            var responseDto = new LoginResponseDto();
            responseDto.Token = handler.WriteToken(jwtSecurityToken);
            responseDto.ExpireDate = DateTime.UtcNow.AddMinutes(_jwtTokenOptions.ExpireInMinutes);
            return responseDto;


        }
    }
    
    
}
