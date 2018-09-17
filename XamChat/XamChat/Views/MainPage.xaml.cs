using Splat;
using Xamarin.Forms;
using XamChat.Services;
using XamChat.Views;

namespace XamChat
{
    public partial class MainPage : ContentPage
    {
        private IUserService _userService;

        public MainPage(IUserService userService = null)
        {
            InitializeComponent();
            _userService = userService ?? Locator.Current.GetService<IUserService>();
        }

        protected override void OnAppearing()
        {
            if (!_userService.IsAuthenticated) Navigation.PushModalAsync(new LoginPage(), false);
            base.OnAppearing();
        }
    }
}
