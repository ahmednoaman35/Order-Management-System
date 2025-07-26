using AutoMapper;
using Doiman.Contracts;
using Doiman.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServiesAbstractions;
using Sheared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Servies
{
    partial class UserService(UserManager<User> userManager, IUnitOfWork iunitofwork, IOptions<JwtOptions> options, IMapper mapper, RoleManager<IdentityRole> _roleManager) : IUserService
    {

        public async Task<UserResultDto> LoginAsync(LoginDto loginDto)
        {
            var user = await userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) throw new UnAuthorizedEception("Email Doesn't Exist");

            // Check if the password is correct for this email
            var result = await userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!result) throw new UnAuthorizedEception("Password Doesn't Exist");

            // Create Token And Return Response
            return new UserResultDto(user.Displayname, user.Email!, await CreateTokenAsync(user));


        }

        public async Task<UserResultDto> RegisterAsync(UserRegisterDto registerDto)
        {


            var user = new User()
            {
                Email = registerDto.Email,
                Displayname = registerDto.DisplayName,
                PhoneNumber = registerDto.PhoneNumber,
                UserName = registerDto.UserName,
            };

            var result = await userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                throw new ValidationExceotion(errors);
            }

            return new UserResultDto(user.Displayname, user.Email, await CreateTokenAsync(user));
        }

        private async Task<string> CreateTokenAsync(User user)
        {
            var jwtoptions = options.Value;
            // Private Claims
            var authClaims = new List<Claim>
            {
             new Claim(ClaimTypes.Name,  user.UserName!),
              new Claim( ClaimTypes.Email,  user.Email!),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            // Add Roles To Claims If Exist
            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtoptions.SecretKey));
            var signingCreds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                audience: jwtoptions.Audience,
                issuer: jwtoptions.Issuer,
                expires: DateTime.UtcNow.AddDays(jwtoptions.DurationInDays),
                claims: authClaims,
                signingCredentials: signingCreds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
