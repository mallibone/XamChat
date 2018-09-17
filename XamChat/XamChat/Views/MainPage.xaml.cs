using Splat;
using Xamarin.Forms;
using XamChat.Services;
using XamChat.ViewModels;
using XamChat.Views;

namespace XamChat
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            if (!ViewModel.IsAuthenticated) Navigation.PushModalAsync(new LoginPage(), false);
            base.OnAppearing();
        }

        private MainViewModel ViewModel { get; } = new MainViewModel();
    }
}
