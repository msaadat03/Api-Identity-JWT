using Microsoft.AspNetCore.Mvc;
using Service.DTO_s.Account;
using Service.Services.Interfaces;

namespace Application.Controllers
{
    public class AccountController : ApplicationController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDTO user)
        {
            return Ok(await _accountService.RegisterAsync(user));
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO user)
        {
            return Ok(await _accountService.LoginAsync(user));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RoleDTO role)
        {
            await _accountService.CreateRoleAsync(role);

            return Ok();
        }
    }
}
