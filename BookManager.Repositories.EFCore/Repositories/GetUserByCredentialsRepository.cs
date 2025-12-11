using BookManager.BusinessObjects.DTOs.Login;
using BookManager.BusinessObjects.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Repositories.EFCore.Repositories
{
    internal class GetUserByCredentialsRepository : IGetUserByCredentialsRepository
    {
        readonly UserManager<IdentityUser> UserManager;
        public GetUserByCredentialsRepository(UserManager<IdentityUser> userManager)
        {
            UserManager = userManager;
        }
        public async Task<UserDto> GetUserByCredentials(UserCredentialsDto userData)
        {
            UserDto FoundUser = default;

            var User = await UserManager.FindByNameAsync(userData.UserName);
            if (User != null &&
               await UserManager.CheckPasswordAsync(User, userData.Password))
            {
                FoundUser = new UserDto(User.UserName, User.Email);
            }

            return FoundUser;
        }
    }
}
