using ExerciseDI_FeedReader;
using Microsoft.Extensions.DependencyInjection;

namespace FeedTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ServiceproviderGetFeed_YoutubeFeed_ReturnsVideo()
        {
            IServiceProvider serviceProvider;
            var services = new ServiceCollection();
            services.AddSingleton<IFeed, YouTubeFeedReader>();
            serviceProvider = services.BuildServiceProvider(true);

            FeedService youtubeService = new FeedService(serviceProvider.GetService<IFeed>());
            String ytfeed = youtubeService.GetFeed();

            Assert.AreEqual(ytfeed, "Video:item 1");
        }
    }
}