using HamsterSqueaks.Server.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HamsterSqueaks.Server.Data;
using HamsterSqueaks.Server.Exceptions;
using Microsoft.EntityFrameworkCore;
using HamsterSqueaks.Server.Helpers;

namespace HamsterSqueaks.Server.Services
{
    /// <summary>
    /// Service providing functionality for HamsterSqueakUser entities.
    /// </summary>
    public class UserService : IUserService
    {
        private HamsterSqueaksDbContext _dbContext;

        public UserService(HamsterSqueaksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets all models.
        /// </summary>
        /// <returns>A list of models in ViewModels.</returns>
        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            return await _dbContext.Users.Select(x => new UserViewModel(x)).ToListAsync();
        }

        /// <summary>
        /// Gets a model by its Id.
        /// </summary>
        /// <returns>The model in a ViewModel.</returns>
        public async Task<UserViewModel> Get(string Id)
        {
            var dbModel = await _dbContext.Users.SingleAsync(x => x.Id.Equals(Id));
            ServiceHelpers.ThrowIfNotFound(dbModel);

            return new UserViewModel(dbModel);
        }

        /// <summary>
        /// Creates a new model.
        /// </summary>
        /// <returns>The created model in a ViewModel.</returns>
        public async Task<UserViewModel> Create(UserViewModel viewModel)
        {
            var model = viewModel.Model;
            ServiceHelpers.ThrowIfMissing(model);

            _dbContext.Users.Add(model);
            await _dbContext.SaveChangesAsync();

            return viewModel;
        }

        /// <summary>
        /// Edits a model.
        /// </summary>
        /// <returns>The updated model in a ViewModel.</returns>
        public async Task<UserViewModel> Edit(UserViewModel viewModel)
        {
            var model = viewModel.Model;
            ServiceHelpers.ThrowIfMissing(model);

            var dbModel = Get(viewModel.Id);
            ServiceHelpers.ThrowIfNotFound(dbModel);

            _dbContext.Entry(dbModel).CurrentValues.SetValues(model);
            await _dbContext.SaveChangesAsync();

            return viewModel;
        }

        /// <summary>
        /// Deletes the model.
        /// </summary>
        /// <returns>The deleted model in a ViewModel.</returns>
        public async Task<UserViewModel> Delete(UserViewModel viewModel)
        {
            var model = viewModel.Model;
            ServiceHelpers.ThrowIfMissing(model);

            _dbContext.Remove(model);
            await _dbContext.SaveChangesAsync();

            return viewModel;
        }
    }
}
