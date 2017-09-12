using HamsterSqueaks.Server.Models;

namespace HamsterSqueaks.Server.ViewModels
{
    /// <summary>
    /// A base user in the HamsterSqueak system.
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// The users Id. Note this is a Guid.
        /// </summary>
        public string Id { get { return _model.Id; } set { _model.Id = value; } }

        /// <summary>
        /// The users email.
        /// </summary>
        public string Email { get { return _model.Email; } set { _model.Email = value; } }

        /// <summary>
        /// The users UserName.
        /// </summary>
        public string UserName { get { return _model.UserName; } set { _model.UserName = value; } }

        /// <summary>
        /// The users password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The confirmed user password.
        /// </summary>
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// The underlying model for this view model.
        /// </summary>
        public HamsterSqueaksUser Model { get { return _model; } set { _model = value; } }

        private HamsterSqueaksUser _model { get; set; }

        /// <summary>
        /// Default contructor. 
        /// </summary>
        /// <param name="model">The HamsterSqueaksUser model to base the UserViewModel of.</param>
        public UserViewModel(HamsterSqueaksUser model = default(HamsterSqueaksUser))
        {
            _model = model ?? new HamsterSqueaksUser();
        }
    }
}
