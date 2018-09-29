using Splat;
using Xamarin.Forms;
using XamChat.Services;
using XamChat.ViewModels;
using XamChat.Views;

namespace XamChat
{
    public partial class MainPage : ContentPage
    {
        bool _onAppearingInitial = true;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = ViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (_onAppearingInitial && !ViewModel.IsAuthenticated) await Navigation.PushModalAsync(new LoginPage(), false);
            _onAppearingInitial = !_onAppearingInitial;
            ChatMessage.Focus();
        }

        private MainViewModel ViewModel { get; } = new MainViewModel();
    }
}
