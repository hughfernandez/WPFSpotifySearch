using System.Collections.Generic;

namespace SpotifyWPFSearch.Models
{
    public class SpotifySearch
    {
        public class ExternalUrls
        {
            public string spotify { get; set; }
        }

        public class Followers
        {
            public int total { get; set; }
        }

        public class ImageSP
        {
            public string url { get; set; }
        }

        public class Item
        {
            public Followers followers { get; set; }
            public string id { get; set; }
            public List<ImageSP> images { get; set; }
            public string name { get; set; }
            public int popularity { get; set; }
        }

        public class Artists
        {
            public List<Item> items { get; set; }
        }

        public class SpotifyResult
        {
            public Artists artists { get; set; }
        }
    }
}
