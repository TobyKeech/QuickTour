using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using QuickTour.Areas.Users.ViewModels;
using QuickTour.Configuration;
using QuickTour.Models;
using System.Reflection;

namespace QuickTour.Areas.Users.Controllers
{
    [Area("Users")]
    public class ForumController : Controller
    {

        private readonly ILogger<ForumController> _logger;
        private readonly IForumContext _context;
        private readonly ITransient _tran;
        private readonly IScoped _scoped;
        private readonly ISingleton _single;
        private readonly FeaturesConfiguration _features;
        private readonly IConfiguration _config;

        public ForumController(ILogger<ForumController> logger, IForumContext context, ITransient tran, IScoped scoped,
            ISingleton single, IOptions<FeaturesConfiguration>features, IConfiguration config)
        {
            _logger = logger;
            _context = context;
			_tran = tran;
            _scoped = scoped;
            _single = single;
            _features = features.Value;
            _config = config;
        }

        public IActionResult Index()
        {
            _logger.LogInformation($"MyOption1 = {_features.EnableMyOption1}, MyOption2 = {_features.EnableMyOption2}");
			_logger.LogInformation($"MyOption1 = {_config["Features:EnableMyOption1"]}, MyOption2 = {_config["Features:EnableMyOption2"]}");
			_logger.LogInformation("In the Forums Index() method <========");

            _tran.WriteGuidToConsole();
            _scoped.WriteGuidToConsole();
            _single.WriteGuidToConsole();

            _logger.LogDebug("About to get the data");
           
            IEnumerable<Forum> forums = _context.GetForums();

            _logger.LogDebug($"Number of forums: {forums.Count()}");
            return View(ForumViewModel.FromForums(forums));
        }
    }
}
