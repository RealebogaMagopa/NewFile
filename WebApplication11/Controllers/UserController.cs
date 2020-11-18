﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


using Microsoft.Extensions.Configuration;

namespace WebApplication11.Controllers
{
    

    
    public class UserController : Controller
    {
        private readonly IConfiguration config;

        public UserController(IConfiguration config)
        {
            this.config = config;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
