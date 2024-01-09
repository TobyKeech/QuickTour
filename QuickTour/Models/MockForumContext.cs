namespace QuickTour.Models
{
	public class MockForumContext
	{
		public IEnumerable<Forum> GetForums ()
		{
			List<Thread>topic1Threads = new List<Thread>()
			{
				new Thread()
				{
					Title = "Thread 1",
					UserName = "User 1",
					DateCreated= new DateTime(2020, 1, 28)
				},

				new Thread()
				{
					Title = "Thread 2",
					UserName = "User 2",
					DateCreated= new DateTime(2020, 1, 31)
				}

			}
			;

			return new List<Forum>()
			{
				new Forum() { Title = "Topic 1", Threads = topic1Threads},
				new Forum() { Title = "Topic2", Threads = new List<Thread>()}
			};
		}
	}
}
