using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceBase.Services;
using StructureMap;

namespace WebBaseBootstrap.Controllers
{
    public class HomeController : Controller
    {
        public UserService UserService { get; set; }

        // GET: /Home/

        public ActionResult Index()
        {
            // DEBUG
            System.Diagnostics.Debug.WriteLine(ObjectFactory.WhatDoIHave());

            System.Diagnostics.Debug.WriteLine("User service: " + UserService.ToString());

            return View();
        }

    }
}
