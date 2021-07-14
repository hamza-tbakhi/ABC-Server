using Domain.Models;
using System.Threading.Tasks;
using Domain.DTO;

namespace Service.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDTO> Login(LoginRequestDTO model);

        Task<UserResponseDTO> Register(RegisterDTO model);
        Task<bool> ChangePassword(UpdatePasswordDTO updatePasswordDTO);
    }
}
