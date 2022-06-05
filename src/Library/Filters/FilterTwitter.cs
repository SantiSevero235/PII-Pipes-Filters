using System;
using System.Drawing;
using TwitterUCU;

namespace CompAndDel.Filters
{
    public class FilterTwitter
    {
        public void Filter(string text, string path)
        {
            PictureProvider provider = new PictureProvider();
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter($"{text}", @$"{path}.jpg"));
        }
    }
}