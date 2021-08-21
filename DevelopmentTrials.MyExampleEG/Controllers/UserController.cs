using DevelopmentTrails.SharedModels.UserModels;
using DevelopmentTrials.DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopmentTrials.MyExampleEG.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Create(UserCreateModel user)
        {
            _userService.Create(user);
            return View();
        }

    }
}
