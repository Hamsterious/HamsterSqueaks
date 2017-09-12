using HamsterSqueaks.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamsterSqueaks.Server.Controllers
{
    /// <summary>
    /// Users API endpoints.
    /// </summary>
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
    }
}
