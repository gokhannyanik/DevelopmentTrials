using DevelopmentTrails.SharedModels.UserModels;
using DevelopmentTrials.DataAccessLayer.Interfaces;
using DevelopmentTrials.MessageBroker.Interfaces;
using DevelopmentTrials.MessageBroker.Models;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentTrials.MyExampleEG.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        private readonly IMessageBrokerService _messageBrokerService;

        public UserController(IUserService userService, IMessageBrokerService messageBrokerService)
        {
            _userService = userService;
            _messageBrokerService = messageBrokerService;
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Create(UserCreateModel user)
        {
            _userService.Create(user);

            var message = new RabbitMQMessageModel()
            {
                HostName = "localhost",
                QueueID = "mail-queue",
                Message = user.Email,
            };
            _messageBrokerService.Send(message);


            return View();
        }
        public IActionResult Update(UserUpdateModel user)
        {
            _userService.Update(user);
            return View();
        }
    }
}
