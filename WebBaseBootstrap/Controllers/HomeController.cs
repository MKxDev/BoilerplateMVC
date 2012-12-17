using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceBase.Services;
using StructureMap;
using RepositoryBase.Models;

namespace WebBaseBootstrap.Controllers
{
    public class HomeController : BaseController
    {
        public UserService UserService { get; set; }

        // GET: /Home/

        public ActionResult Index()
        {
            // DEBUG
            System.Diagnostics.Debug.WriteLine("User service: " + UserService.ToString());

            // For shits and giggles:
            var user = new User
            {
                Email = "tes@asdfsafsadfsafagtest.com",
                Salt = "1234",
                Hash="hashish",
            };

            UserService.Save(user);

            return View();
        }
    }
}
