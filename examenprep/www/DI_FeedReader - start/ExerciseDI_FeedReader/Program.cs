using ExerciseDI_FeedReader;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
	private static void Main(string[] args)
	{
        IServiceProvider serviceProvider;
        var services = new ServiceCollection();
		services.AddSingleton<IFeed, BlogFeedReader>();
		services.AddSingleton<IFeed, YouTubeFeedReader>();
		services.AddSingleton<IFeed, PodcastFeedReader>();
		serviceProvider = services.BuildServiceProvider(true);

		// with serviceprovider
        FeedService servicePodcast = new FeedService(serviceProvider.GetServices<IFeed>().ElementAt(2));
		String feed = servicePodcast.GetFeed();        
		
		FeedService youtubeService = new FeedService(serviceProvider.GetServices<IFeed>().ElementAt(1));
		String ytfeed = youtubeService.GetFeed();


        Console.WriteLine(feed);
        Console.WriteLine(ytfeed);

		Console.ReadLine();
	}
}