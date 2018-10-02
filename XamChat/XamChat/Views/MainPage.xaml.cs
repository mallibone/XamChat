using System.Collections.Specialized;
using System.Linq;
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
            if (_onAppearingInitial && !ViewModel.IsAuthenticated)
            {
                await Navigation.PushModalAsync(new LoginPage(), false);
            }
            
            _onAppearingInitial = !_onAppearingInitial;
            Messages.ScrollTo(ViewModel.Messages.LastOrDefault(), ScrollToPosition.End, false);
            ViewModel.Messages.CollectionChanged += MessagesChangedHandler;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ViewModel.Messages.CollectionChanged -= MessagesChangedHandler;
        }

        private void MessagesChangedHandler(object sender, NotifyCollectionChangedEventArgs e)
        {
            Messages.ScrollTo(ViewModel.Messages.Last(), ScrollToPosition.End, true);
        }

        private MainViewModel ViewModel { get; } = new MainViewModel();
    }
}
