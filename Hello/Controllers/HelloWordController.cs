using Hello.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hello.Controllers
{
    public class HelloWordController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HelloWordController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("helloworld")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Route("helloworld/{name}")]
        public IActionResult HelloWithName(string name)
        {
            TempData["UserName"] = name;
            return View("Hello");
        }


        [HttpPost]
        [Route("helloworld")]
        public IActionResult Index(User user)
        {

            TempData["UserName"] = user.Name;
            return RedirectToAction("Hello");
        }

        [HttpGet]
        [Route("helloworld/hello")]
        public IActionResult Hello()
        {
            var userName = string.Empty;
            if (TempData["UserName"] != null)
            {
                userName = TempData["UserName"].ToString();
            }
            else
            {
                if (string.IsNullOrEmpty(userName))
                {
                    userName = "World";
                }
            }

            var user = new User { Name = userName };
            return View(user);
        }



    }
}
