using HamsterSqueaks.Server.Models;
using HamsterSqueaks.Server.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HamsterSqueaks.Server.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetAll();
        Task<UserViewModel> Get(string userId);
        Task<HamsterSqueaksUser> Get();
        Task<IdentityResult> Create(UserViewModel manager);
        Task<IdentityResult> Edit(string userId, UserViewModel manager);
        Task<IdentityResult> SetPassword(string userId, UserViewModel manager);
        Task<UserViewModel> Delete(string userId);
    }
}
