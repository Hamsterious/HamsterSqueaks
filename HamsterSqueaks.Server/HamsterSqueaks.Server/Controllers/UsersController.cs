using HamsterSqueaks.Server.Exceptions;
using HamsterSqueaks.Server.Services;
using HamsterSqueaks.Server.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HamsterSqueaks.Server.Controllers
{
    /// <summary>
    /// Users API endpoints.
    /// </summary>
    [Produces("application/json")]
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        /// <summary>
        /// UsersController constructor.
        /// </summary>
        /// <param name="userService">The UserService Depencency.</param>
        public UsersController(
            IUserService userService
            )
        {
            _userService = userService;
        }

        /// <summary>
        /// Gets all Users.
        /// </summary>
        /// <returns>An array of Users.</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }

        /// <summary>
        /// Gets a single User by ID.
        /// </summary>
        /// <param name="userId">ID of the User object to get.</param>
        /// <returns>A single User object.</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        [HttpGet("{userId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserViewModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(string userId)
        {
            return Ok(await _userService.Get(userId));
        }

        /// <summary>
        /// Create a single User.
        /// </summary>
        /// <param name="user">The User object to create.</param>
        /// <returns>The created User object.</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserViewModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] UserViewModel user)
        {
            if (!ModelState.IsValid) throw new InvalidModelStateException(ModelState);
            var result = await _userService.Create(user);
            if (!result.Succeeded)
            {
                AddErrors(result);
                throw new InvalidModelStateException(ModelState);
            }
            return CreatedAtAction("get", new { userId = user.Id }, new UserViewModel(user.Model));
        }

        /// <summary>
        /// Edits a single User
        /// </summary>
        /// <param name="userId">ID of the User to edit</param>
        /// <param name="user">The User object to edit.</param>
        /// <returns>The updated User object.</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        [HttpPut("{userId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserViewModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Edit(string userId, [FromBody]UserViewModel user)
        {
            if (!ModelState.IsValid) throw new InvalidModelStateException(ModelState);
            var result = await _userService.Edit(userId, user);
            if (!result.Succeeded)
            {
                AddErrors(result);
                throw new InvalidModelStateException(ModelState);
            }
            return Ok(new UserViewModel(user.Model));
        }

        /// <summary>
        /// Updates the Users Password.
        /// </summary>
        /// <param name="userId">ID of the User to edit.</param>
        /// <param name="user">The User object to edit.</param>
        /// <returns>The updated User object.</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        [HttpPut("SetPassword/{userId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserViewModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SetPassword(string userId, [FromBody]UserViewModel user)
        {
            if (!user.Password.Equals(user.ConfirmPassword)) ModelState.AddModelError("ConfirmPassword", "The passwords does not match");
            if (!ModelState.IsValid) throw new InvalidModelStateException(ModelState);
            var validationResult = await _userService.SetPassword(userId, user);
            if (!validationResult.Succeeded)
            {
                AddErrors(validationResult);
                throw new InvalidModelStateException(ModelState);
            }
            return Ok(new UserViewModel(user.Model));
        }

        /// <summary>
        /// Deletes a single User.
        /// </summary>
        /// <param name="userId">ID of the User to delete.</param>
        /// <returns>The deleted User object.</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        [HttpDelete("{userId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserViewModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(string userId)
        {
            // Avoid removing yourself:
            if (User.Identity.IsAuthenticated && (await _userService.Get()).Id.Equals(userId)) throw new ArgumentException("Cannot remove the currently logged in user.");
            return Ok(await _userService.Delete(userId));
        }

        /// <summary>
        /// Adds all errors from an Identity result to the ModelState error list.
        /// </summary>
        /// <param name="result">The IdentityResult containing errors to add to the ModelState.</param>
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);
        }
    }
}
