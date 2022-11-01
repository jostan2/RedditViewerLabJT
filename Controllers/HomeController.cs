using Microsoft.AspNetCore.Mvc;
using RedditViewerLabJT.Models;
using System.Diagnostics;

namespace RedditViewerLabJT.Controllers
{
    public class HomeController : Controller
    {
        RedditDAL api = new RedditDAL(); //

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            RedditPosts r = api.GetPost();
            Data1 d = r.data.children[0].data; //refers to a nested class model (child within the child class) to shorten address line in index. A model inside of a model, condensed.
            return View(d);
        }

        public IActionResult Posts()
        {
            RedditPosts r = api.GetPost();
            Child[] posts = r.data.children;
            return View(posts);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}