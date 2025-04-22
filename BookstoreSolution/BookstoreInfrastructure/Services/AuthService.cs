using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreApplication.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using BookstoreInfrastructure.Identity;
using BookstoreApplication.Features.Authentication.DTOs;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace BookstoreInfrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public AuthService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            var existingEmail = await _userManager.FindByEmailAsync(request.Email);

            if (existingEmail != null)
            {
                return new AuthResponse
                {
                    IsSuccessful = false,
                    Errors = new List<string> { "Email already exists" }
                };
            }


            var user = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                City = request.City,
                ZipCode = request.ZipCode,
                AccountCreationDate = DateTime.Now
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return new AuthResponse
                {
                    IsSuccessful = false,
                    Errors = result.Errors.Select(e => e.Description).ToList()
                };
            }

            return new AuthResponse
            {
                IsSuccessful = true,
                Message = "User registered successfully"
            };
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if(user == null)
            {
                return new AuthResponse
                {
                    IsSuccessful = false,
                    Errors = new List<string> { "Email does not exist" }
                };
            }

            if(user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return new AuthResponse
                {
                    IsSuccessful = false,
                    Errors = new List<string> { "Incorrect password" }
                };
            }

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:DurationInMinutes"])),
                Issuer = _configuration["JwtSettings:Issuer"],
                Audience = _configuration["JwtSettings:Audience"],
                SigningCredentials = creds
            };

            var token = _tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = _tokenHandler.WriteToken(token);

            return new AuthResponse
            {
                IsSuccessful = true,
                Token = jwtToken,
                Email = user.Email,
                UserName = user.UserName,
                Roles = roles
            };
        }
    }
}
