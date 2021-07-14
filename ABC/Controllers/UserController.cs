using Domain.DTO;
using Domain.SearchModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;
using System.Threading.Tasks;

namespace SafeDeliver.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public UserController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> RemoveUser(int userId)
        {
            bool result = await _serviceUnitOfWork.User.Value.RemoveUser(userId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserInfo(UserRequestDTO userInfo)
        {
            var user = await _serviceUnitOfWork.User.Value.UpdateUserInfo(userInfo);
            return Ok(user);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserInfo(int userId)
        {
            var user = await _serviceUnitOfWork.User.Value.GetUserInfo(userId);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> GetUsersList(UserSearchModel search)
        {
            var usersList = await _serviceUnitOfWork.User.Value.GetUsersList(search);
            return Ok(usersList);

        }

        [HttpGet]
        public async Task<IActionResult> GetUserProfile()
        {
            var user = await _serviceUnitOfWork.User.Value.GetUserProfile();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserProfile(UserProfileRequestDTO userProfile)
        {
            var user = await _serviceUnitOfWork.User.Value.UpdateUserProfile(userProfile);
            return Ok(user);
        }

    }
}
