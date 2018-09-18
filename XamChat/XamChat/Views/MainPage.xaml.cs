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

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (!ViewModel.IsAuthenticated) await Navigation.PushModalAsync(new LoginPage(), false);
        }

        private MainViewModel ViewModel { get; } = new MainViewModel();
    }
}
