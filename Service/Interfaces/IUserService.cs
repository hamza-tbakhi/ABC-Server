using Domain.SearchModels;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Models;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDTO> UpdateUserInfo(UserRequestDTO userInfo);
        Task<bool> RemoveUser(int userId);
        Task<ListResponse<UserResponseDTO>> GetUsersList(UserSearchModel search);
        Task<UserResponseDTO> GetUserInfo(int userId);
        Task<UserProfileResponseDTO> GetUserProfile();
        Task<UserProfileResponseDTO> UpdateUserProfile(UserProfileRequestDTO userProfile);
    }
}


