using Domain.DTO;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;

using System.Threading.Tasks;

namespace SafeDeliver.Controllers.auth
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public AuthController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDTO oLoginRequestDTO)
        {
            LoginResponseDTO tokenResponseDTO = await _serviceUnitOfWork.Auth.Value.Login(oLoginRequestDTO);
            return Ok(tokenResponseDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO oRegisterDTO)
        {
            var user = await _serviceUnitOfWork.Auth.Value.Register(oRegisterDTO);
            return Ok(user);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody] UpdatePasswordDTO updatePasswordDTO)
        {
            bool result = await _serviceUnitOfWork.Auth.Value.ChangePassword(updatePasswordDTO);
            return Ok(result);
        }
    }
}
