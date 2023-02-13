using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Dashboard.Helper.Dtos.Account;
using Dashboard.Infrastructure.Serives.interfaces;

namespace Dashboard.Api.api
{
    [Route("api/[controller]")]
    public class AccountController : BaseApiController
    {
        private readonly IJwtHandler _IJwtHandler;
        private readonly IUserAccountService _IUserAccountService;

        public AccountController(IJwtHandler IJwtHandler, IUserAccountService IUserAccountService)
        {
            _IJwtHandler = IJwtHandler;
            _IUserAccountService = IUserAccountService;
        }

        [HttpPost, Route("GetUserByToken")]
        public async Task<IActionResult> GetUserByToken(string token)
        {
            try
            {
                var data = await _IUserAccountService.GetUserByToken(token);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Ok(ex.ToString());
            }

        }

        [AllowAnonymous, HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(LoginDTO loginDto)
        {
            try
            {
                var loginResult = await _IUserAccountService.LoginUser(loginDto, Request.Headers);
                if (!loginResult.loginSuccessful)
                {
                    return Unauthorized("Invalid Authentication");
                }

                LoginResponseDTO loginResponseDTO = new()
                {
                    UserName = loginResult.user.UserName,
                    MobileNo = loginResult.user.PhoneNumber,
                    Email = loginResult.user.Email,
                    Token = _IJwtHandler.GetToken(loginResult.user),
                    UserId = loginResult.user.Id
                };

                return Ok(loginResponseDTO);
            }
            catch (System.Exception ex)
            {
                return Unauthorized(ex.ToString());
            }
        }


        [AllowAnonymous, HttpPost("ResetPassword")]
        public async Task<bool> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            return await _IUserAccountService.ResetPassword(resetPasswordDTO);
        }



        [AllowAnonymous, HttpPost, Route("Authorize")]
        public async Task<IActionResult> Authorize(string token)
        {
            try
            {
                var data = await _IUserAccountService.ValidateToken(token);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Ok(ex.ToString());
            }
        }

        [AllowAnonymous, HttpPost, Route("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            try
            {
                var data = await _IUserAccountService.RegisterUser(registerDTO);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Ok(ex.ToString());
            }
        }


        [AllowAnonymous, HttpGet, Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(_IUserAccountService.GetAllUsers());
            }
            catch (Exception ex)
            {
                return Ok(ex.ToString());
            }
        }

    }
}
