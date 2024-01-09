using System.ComponentModel.DataAnnotations;

namespace QuickTour.Models
{
    public class Forum
    {
		public int ForumId { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Thread> Threads { get; set; }


        
    }
}
