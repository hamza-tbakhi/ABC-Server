using AutoMapper;
using Domain.DTO;
using Domain.Models;
using Domain.SearchModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.UnitOfWork;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork; 
        private UserManager<ApplicationUser> _userManager;
        private LoggedInUserService _loggedInUserService;
        private IMapper _mapper;
        public UserService(UserManager<ApplicationUser> userManager,
            IRepositoryUnitOfWork repositoryUnitOfWork,
            LoggedInUserService loggedInUserService,
            IMapper mapper)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _userManager = userManager;
            _loggedInUserService = loggedInUserService;
            _mapper = mapper;
        }

        public async Task<UserResponseDTO> UpdateUserInfo(UserRequestDTO userInfo)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userInfo.Id.ToString());

            if (_userManager.Users.Any(x => x.PhoneNumber == userInfo.PhoneNumber && x.Id != userInfo.Id))
            {
                throw new ValidationException("DUPLICATE_PHONE");
            }
            
            user.Email = userInfo.Email;
            user.PhoneNumber = userInfo.PhoneNumber;
            user.FullName = userInfo.FullName;
            user.IsActive = userInfo.IsActive;

            IdentityResult result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return _mapper.Map<UserResponseDTO>(user); ;
            }
            throw new Exception("Error in Updating User Info");
        }

        public async Task<bool> RemoveUser(int userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                throw new ValidationException("User not found");
            }

            IdentityResult result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return true;
            }
            else if (result.Errors.Any())
            {
                throw new Exception(result.Errors.FirstOrDefault().Description);
            }
            else
            {
                throw new Exception("Error while removing user");
            }
        }

        public async Task<UserResponseDTO> GetUserInfo(int userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());
            UserResponseDTO userDTO = _mapper.Map<UserResponseDTO>(user);
            return userDTO;
        }

        public async Task<ListResponse<UserResponseDTO>> GetUsersList(UserSearchModel search)
        {
            List<ApplicationUser> users = await _userManager.Users.Where(x => x.UserRoles.Any(y => y.RoleId == search.RoleType) &&
                                                                              (!search.IsActive.HasValue || x.IsActive == search.IsActive))
                                                                  .OrderByDescending(x => x.Id)
                                                                  .ToListAsync();

            int pageCount = (users.Count() + search.PageSize - 1) / search.PageSize;

            users = users.Skip(search.PageSize * (search.PageNo - 1)).Take(search.PageSize).ToList();

            ListResponse<UserResponseDTO> UsersListResponse = new ListResponse<UserResponseDTO>
            {
                entities = _mapper.Map<List<UserResponseDTO>>(users),
                TotalCount = pageCount
            };
          
            return UsersListResponse;
        }


        // For LoggedIn User
        public async Task<UserProfileResponseDTO> GetUserProfile()
        {
            long userId = _loggedInUserService.GetUserId();
            ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());
            UserProfileResponseDTO userProfileDTO = _mapper.Map<UserProfileResponseDTO>(user);
            return userProfileDTO;
        }

        public async Task<UserProfileResponseDTO> UpdateUserProfile(UserProfileRequestDTO userProfile)
        {
            long userId = _loggedInUserService.GetUserId();
            ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());

            user.Email = userProfile.Email;
            user.PhoneNumber = userProfile.PhoneNumber;
            user.FullName = userProfile.FullName;

            IdentityResult result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return _mapper.Map<UserProfileResponseDTO>(user); ;
            }
            throw new Exception("Error in Updating User Info");
        }
    }
}
