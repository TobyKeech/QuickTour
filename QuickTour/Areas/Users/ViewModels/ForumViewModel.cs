using QuickTour.Models;
using System.ComponentModel.DataAnnotations;

namespace QuickTour.Areas.Users.ViewModels
{
    public class ForumViewModel
    {
        [ScaffoldColumn(false)]
        public int ForumId { get; set; }
        public string Title { get; set; }
        public int NumberOfThreads { get; set; }
        public DateTime? LatestThreadDate { get; set; }

        public static ForumViewModel FromForum(Forum forum)
        {
            return new ForumViewModel
            {
                ForumId = forum.ForumId,
                Title = forum.Title,
                NumberOfThreads = forum.Threads.Count,
                LatestThreadDate = forum.Threads.DefaultIfEmpty().Max(t => t?.DateCreated)
            };
        }

        public static IEnumerable<ForumViewModel> FromForums
                                        (IEnumerable<Forum> forums)
        {
            return forums.Select(f => FromForum(f));
        }
    }



}
