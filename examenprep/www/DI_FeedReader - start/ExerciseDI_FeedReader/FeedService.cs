using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseDI_FeedReader
{
    public class FeedService
    {
        IFeed _feed;

        public FeedService(IFeed feed) 
        {
            _feed = feed;
        }

        public string GetFeed()
        {
            return _feed.GetSingleFeed();      
        }
    }
}
