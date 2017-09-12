using HamsterSqueaks.Server.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HamsterSqueaks.Server.Services
{
    /// <summary>
    /// Interface for the UserService
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets all models.
        /// </summary>
        /// <returns>A list of models in ViewModels.</returns>
        Task<IEnumerable<UserViewModel>> GetAll();

        /// <summary>
        /// Gets a model by its Id.
        /// </summary>
        /// <returns>The model in a ViewModel.</returns>
        Task<UserViewModel> Get(string Id);

        /// <summary>
        /// Creates a new model.
        /// </summary>
        /// <returns>The created model in a ViewModel.</returns>
        Task<UserViewModel> Create(UserViewModel viewModel);

        /// <summary>
        /// Edits a model.
        /// </summary>
        /// <returns>The updated model in a ViewModel.</returns>
        Task<UserViewModel> Edit(UserViewModel viewModel);

        /// <summary>
        /// Deletes the model.
        /// </summary>
        /// <returns>The deleted model in a ViewModel.</returns>
        Task<UserViewModel> Delete(UserViewModel viewModel);
    }
}
