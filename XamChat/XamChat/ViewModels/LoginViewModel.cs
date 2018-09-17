using System;
using Splat;
using Xamarin.Forms;
using XamChat.Services;

namespace XamChat.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        private readonly IUserService _userService;

        public LoginViewModel(IUserService userService = null)
        {
            LoginCommand = new Command(AuthenticateUser);
            _userService = userService ?? Locator.Current.GetService<IUserService>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public Command LoginCommand { get; set; }
        public Action UserAuthenticatedCallback { get; set; } = () => {};

        private async void AuthenticateUser()
        {
            IsBusy = true;
            await _userService.Authenticate(Username, Password);
            IsBusy = false;
            UserAuthenticatedCallback();
        }
    }
}
