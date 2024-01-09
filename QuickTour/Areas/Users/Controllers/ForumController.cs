using Microsoft.AspNetCore.Mvc;
using QuickTour.Areas.Users.ViewModels;
using QuickTour.Models;
using System.Reflection;

namespace QuickTour.Areas.Users.Controllers
{
    [Area("Users")]
    public class ForumController : Controller
    {

        private readonly ILogger<ForumController> _logger;

        public ForumController(ILogger<ForumController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            _logger.LogInformation("In the Forums Index() method <========");
            MockForumContext mockForum = new MockForumContext();
            IEnumerable<Forum> forums = mockForum.GetForums();

            _logger.LogDebug($"Number of forums: {forums.Count()}");
            return View(ForumViewModel.FromForums(forums));
        }
    }
}
