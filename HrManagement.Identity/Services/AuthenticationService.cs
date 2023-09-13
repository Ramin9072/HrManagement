using HrManagement.Application.Contracts.Identity;
using HrManagement.Application.DTOs.Indentity;
using HrManagement.Identity.Constants;
using HrManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;

namespace HrManagement.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        #region DI

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtTokenSetting _jwtSetting;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthenticationService(UserManager<ApplicationUser> userManager,
            JwtTokenSetting jwtSettings,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _jwtSetting = jwtSettings;
            _signInManager = signInManager;
        }
        #endregion

        #region LOGIN
        public async Task<AuthenticationResponse> Login(AuthenticationRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new Exception($"{request.Email} has not found in database");
            var result = await _signInManager
                .PasswordSignInAsync(request.Email, request.Password,isPersistent:false , lockoutOnFailure:false);

            if (!result.Succeeded)
                throw new Exception("Password is incorrect");

            JwtSecurityToken token = await GenerateToken(user);

            AuthenticationResponse response = new AuthenticationResponse() {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Email = user.Email,
                UserName = user.UserName
            };

            return response;
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userCalaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaim = new List<Claim>();
            for (int i = 0; i < roles.Count(); i++)
            {
                roleClaim.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti,new Guid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email,user.Email),
            new Claim(CustomClaimTypes.UserId,user.UserName),
            }
            .Union(userCalaims)
            .Union(roleClaim);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Key));

            var signingCredential = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurotyToken = new JwtSecurityToken(
                issuer: _jwtSetting.Issuer,
                audience: _jwtSetting.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSetting.DuraionInMinutes),
                signingCredentials: signingCredential
                );

            return jwtSecurotyToken;
        }

        #endregion

        #region Register

        public async Task<RegistrationResponse> RegistrationRequest(RegistrationRequest request)
        {
            var existingUserName = await _userManager.FindByNameAsync(request.UserName);
            if (existingUserName != null)
                throw new Exception($"{request.UserName} has already added in database");

            var newUser = new ApplicationUser
            {
                Email = request.EmailAddress,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true
            };

            var existingByEmail = await _userManager.FindByEmailAsync(request.EmailAddress);
            if (existingByEmail == null)
            {
                var result = await _userManager.CreateAsync(newUser, request.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, "Employee");
                    return new RegistrationResponse() { UserId = newUser.Id };
                }
                else
                {
                    throw new Exception($"{result.Errors}");
                }
            }
            else
            {
                throw new Exception($"{request.EmailAddress} has already added in database");
            }
        }
        #endregion
    }
}
