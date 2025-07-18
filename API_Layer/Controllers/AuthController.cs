﻿using DomainLayer.Constants;
using DomainLayer.DTOs;
using DomainLayer.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [Authorize(Roles = Roles.SuperAdmin)]
        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var response = await _authService.Register(registerDto);

            if (response.IsAuthenticated is false)
                return BadRequest(response.Message);

            SetTokenCookie(response.RefreshToken, response.RefreshTokenExpiresOn);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {
            var response = await _authService.Login(loginDto);

            if (response.IsAuthenticated is false)
                return BadRequest(response.Message);

            SetTokenCookie(response.RefreshToken, response.RefreshTokenExpiresOn);

            return Ok(response);
        }

        private void SetTokenCookie(string token, DateTime expirationDate)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expirationDate.ToLocalTime()
            };
            Response.Cookies.Append("RefreshToken", token, cookieOptions);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RefreshToken")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["RefreshToken"];
            if (string.IsNullOrEmpty(refreshToken))
                return BadRequest("Invalid token");
            var response = await _authService.RefreshToken(refreshToken);
            if (response.IsAuthenticated is false)
                return BadRequest(response.Message);
            SetTokenCookie(response.RefreshToken, response.RefreshTokenExpiresOn);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RevokeToken")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenDto revokeTokenDto)
        {
            var token = revokeTokenDto.Token ?? Request.Cookies["RefreshToken"];
            if (string.IsNullOrEmpty(token))
                return BadRequest("Invalid token");
            var response = await _authService.RevokeToken(token);
            if (response is false)
                return BadRequest("Invalid token");
            return Ok(response);
        }
    }
}