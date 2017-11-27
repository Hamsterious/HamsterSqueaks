using HamsterSqueaks.Server.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HamsterSqueaks.Server.Helpers;
using Microsoft.AspNetCore.Identity;
using HamsterSqueaks.Server.Models;
using Microsoft.AspNetCore.Http;

namespace HamsterSqueaks.Server.Services
{
    /// <summary>
    /// Service providing functionality for HamsterSqueakUser entities.
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// Read-only access to the UserManager.
        /// </summary>
        private readonly UserManager<HamsterSqueaksUser> _userManager;
        private readonly IHttpContextAccessor _httpContext;

        /// <summary>
        /// Default constructor with injected services.
        /// </summary>
        /// <param name="userManager">Injected UserManager service.</param>
        /// <param name="httpContext">Injected HTTP context.</param>
        public UserService(
            UserManager<HamsterSqueaksUser> userManager,
            IHttpContextAccessor httpContext
            )
        {
            _userManager = userManager;
            _httpContext = httpContext;
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>List of all users.</returns>
        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            return (await _userManager.Users.ToListAsync()).Select(x => new UserViewModel(x));
        }

        /// <summary>
        /// Gets a single user.
        /// </summary>
        /// <param name="userId">Id of the user.</param>
        /// <returns>User view model.</returns>
        public async Task<UserViewModel> Get(string userId)
        {
            var model = await _userManager.FindByIdAsync(userId);
            ServiceHelpers.ThrowIfNotFound(model);
            return new UserViewModel(model);
        }

        /// <summary>
        /// Gets a single user using ClaimsPrincipal.
        /// </summary>
        /// <returns></returns>
        public async Task<HamsterSqueaksUser> Get()
        {
            return await _userManager.GetUserAsync(_httpContext.HttpContext.User);
        }

        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <param name="user">User view model.</param>
        /// <returns>IdentityResult of the create process.</returns>
        public async Task<IdentityResult> Create(UserViewModel user)
        {
            return await _userManager.CreateAsync(user.Model, user.Password);
        }

        /// <summary>
        /// Edits a user by ID.
        /// </summary>
        /// <param name="userId">ID of the user.</param>
        /// <param name="viewModel">User view model.</param>
        /// <returns>IdentityResult of the edit process.</returns>
        public async Task<IdentityResult> Edit(string userId, UserViewModel viewModel)
        {
            viewModel.Model.Id = userId;
            var model = await _userManager.FindByIdAsync(userId.ToString());
            ServiceHelpers.ThrowIfNotFound(model);
            model.Email = viewModel.Email ?? model.Email;
            return await _userManager.UpdateAsync(model);
        }

        /// <summary>
        /// Sets a password for an existing user, by ID.
        /// </summary>
        /// <param name="userId">Id of the user.</param>
        /// <param name="viewModel">User view model.</param>
        /// <returns>IdentityResult of the validation proccess.</returns>
        public async Task<IdentityResult> SetPassword(string userId, UserViewModel viewModel)
        {
            var model = await _userManager.FindByIdAsync(userId.ToString());
            ServiceHelpers.ThrowIfNotFound(model);

            var validationResult = await new PasswordValidator<HamsterSqueaksUser>().ValidateAsync(_userManager, model, viewModel.Password);
            if (validationResult.Succeeded)
            {
                await _userManager.RemovePasswordAsync(model);
                await _userManager.AddPasswordAsync(model, viewModel.Password);
            }
            return validationResult;
        }

        /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <param name="userId">ID of the user.</param>
        /// <returns>Deleted user view model.</returns>
        public async Task<UserViewModel> Delete(string userId)
        {
            var model = await _userManager.Users.SingleOrDefaultAsync(x => x.Id.Equals(userId));
            ServiceHelpers.ThrowIfNotFound(model);

            await _userManager.DeleteAsync(model);
            return new UserViewModel(model);
        }
    }
}
