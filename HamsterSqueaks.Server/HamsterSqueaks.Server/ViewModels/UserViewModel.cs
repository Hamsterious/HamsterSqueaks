using HamsterSqueaks.Server.Models;

namespace HamsterSqueaks.Server.ViewModels
{
    /// <summary>
    /// A base user in the HamsterSqueak system.
    /// </summary>
    public class UserViewModel
    {

        #region Public properties

        /// <summary>
        /// The underlying model for this view model.
        /// </summary>
        public HamsterSqueaksUser Model { get { return _model; } set { _model = value; } }

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

        #endregion

        private HamsterSqueaksUser _model { get; set; }

        #region Constructors

        /// <summary>
        /// Default contructor. Create a new HamsterSqueaksUser model to base the UserViewModel off.
        /// </summary>
        public UserViewModel()
        {
            _model = new HamsterSqueaksUser();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">The HamsterSqueaksUser model to base the UserViewModel off.</param>
        public UserViewModel(HamsterSqueaksUser model)
        {
            _model = model;
        }

        #endregion
    }
}
