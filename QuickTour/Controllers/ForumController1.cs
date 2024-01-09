using Microsoft.AspNetCore.Mvc;
using QuickTour.Models;
using System.Reflection;

namespace QuickTour.Controllers
{
    public class ForumController1 : Controller
    {
        public IActionResult Index()
        {

            Forum forum = new Forum { ForumId = 1, Title = "First Forum" };
            ViewBag.Forum = forum;
            return View();
        }
    }
}
