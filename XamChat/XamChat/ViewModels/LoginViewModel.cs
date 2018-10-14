using System;
using ReactiveUI;
using Splat;
using Xamarin.Forms;
using XamChat.Services;

namespace XamChat.ViewModels
{
    class LoginViewModel : ReactiveObject
    {
        private readonly IUserService _userService;
        private bool _isBusy;
        private string _username;

        public LoginViewModel(IUserService userService = null)
        {
            var validLoginData = this.WhenAnyValue(x => x.Username, username => !string.IsNullOrEmpty(username));
            LoginCommand = ReactiveCommand.Create(AuthenticateUser, validLoginData);
            _userService = userService ?? Locator.Current.GetService<IUserService>();
        }

        public string Username
        {
            get => _username;
            set => this.RaiseAndSetIfChanged(ref _username, value);
        }
        public string Password { get; set; }

        public bool IsBusy
        {
            get => _isBusy;
            set => this.RaiseAndSetIfChanged(ref _isBusy, value);
        }
        public ReactiveCommand LoginCommand { get; set; }
        public Action UserAuthenticatedCallback { get; set; } = () => {};

        private async void AuthenticateUser()
        {
            IsBusy = true;
            var isAuthenticated = await _userService.Authenticate(Username, Password);
            IsBusy = false;
            if (!isAuthenticated) return;
            UserAuthenticatedCallback();
            UserAuthenticatedCallback = () => { };
        }
    }
}
