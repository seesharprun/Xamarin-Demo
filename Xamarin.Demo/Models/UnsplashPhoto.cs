using System;

namespace Xamarin.Demo.Models
{
    public class UnsplashPhoto
    {
        public string Color { get; set; }

        public string Description { get; set; }

        public User User { get; set; }

        public UrlSet Urls { get; set; }
    }

    public class UrlSet
    {
        public Uri Raw { get; set; }

        public Uri Full { get; set; }

        public Uri Regular { get; set; }

        public Uri Small { get; set; }

        public Uri Thumb { get; set; }
    }

    public class User
    {
        public string Name { get; set; }

        public string Username { get; set; }

        public string Bio { get; set; }
    }
}