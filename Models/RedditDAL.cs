using RestSharp;

namespace RedditViewerLabJT.Models
{
    public class RedditDAL
    {
        public RedditPosts GetPost()
        {
            var client = new RestClient($"https://www.reddit.com/r/aww/.json");
            var request = new RestRequest();
            var response = client.GetAsync<RedditPosts>(request);
            RedditPosts sp = response.Result;
            return sp;
        }
    }
}
