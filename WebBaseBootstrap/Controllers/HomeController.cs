using System.Web;
using System.Web.Mvc;
using ServiceBase.Services;

namespace WebBaseBootstrap.Controllers
{
    public class HomeController : BaseController
    {
        public const string Name = "Home";

        public UserService UserService { get; set; }

        // GET: /Home/

        public ActionResult Index()
        {

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                // DEBUG
                System.Diagnostics.Debug.WriteLine("Congrats, you're authed!");
            }
            else
            {
                // DEBUG
                System.Diagnostics.Debug.WriteLine("Oops, you need to login!");
            }

            return View();
        }
    }
}
