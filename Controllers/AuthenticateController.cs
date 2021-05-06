using ApiAuthDemo.Infrastructure.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using StoreCandidates.Model;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;

namespace StoreCandidates.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public partial class AuthenticateController : ControllerBase
    {
        private readonly TokenManagement _tokenManagement;

        public AuthenticateController(ILogger<AuthenticateController> logger, TokenManagement tokenManagement)
        {
            _tokenManagement = tokenManagement;
        }

        /// <summary>
        /// login to authenticate
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">Returns the userName and jwtToken</response>
        /// <response code="400">If the item is null</response>            
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(LoginResult), StatusCodes.Status200OK)]
        public ActionResult Authentication([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }

            if (!IsValidUser(request.UserName, request.Password))
            {
                return BadRequest("Invalid Request");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,request.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(
                _tokenManagement.Issuer,
                _tokenManagement.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration),
                signingCredentials: credentials);
            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return Ok(new LoginResult
            {
                UserName = request.UserName,
                JwtToken = token
            });
        }

        private bool IsValidUser(string userName, string password)
        {

            if (string.IsNullOrWhiteSpace(userName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }
            return true;
        }
    }
}
