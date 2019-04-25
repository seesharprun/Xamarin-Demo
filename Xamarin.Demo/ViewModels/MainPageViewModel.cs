using Flurl;
using Flurl.Http;
using Prism.Commands;
using Prism.Navigation;
using System;
using Xamarin.Demo.Models;

namespace Xamarin.Demo.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private string _message;        
        private byte[] _image;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public byte[] Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }

        public DelegateCommand LoadCommand { get; private set; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            LoadCommand = new DelegateCommand(LoadExecute);

            Title = "Main Page";
            Message = "Welcome to Xamarin Forms and Prism!";
        }

        private async void LoadExecute()
        {
            Loading = true;

            var photo = await "https://api.unsplash.com/"
                .AppendPathSegments("photos", "random")
                .SetQueryParam("client_id", "")
                .WithHeader("Accept-Version", "v1")
                .GetJsonAsync<UnsplashPhoto>();

            Message = $"Photographer: {photo.User.Name}";
            
            Image = await photo.Urls.Regular
                .AbsoluteUri
                .GetBytesAsync();

            Loading = false;
        }
    }
}