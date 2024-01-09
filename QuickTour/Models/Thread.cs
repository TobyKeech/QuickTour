namespace QuickTour.Models
{
	public class Thread
	{
		public int ThreadId {  get; set; }
		public string Title { get; set; }
		public string UserName { get; set; }
		public DateTime DateCreated {  get; set; }
		public int ForumId { get; set; }
		public virtual Forum Forum { get; set; }
	}
}
