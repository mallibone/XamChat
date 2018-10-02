using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamChat.ViewModels;

namespace XamChat.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            switch (Device.RuntimePlatform)
            {
                case Device.macOS:
                case Device.GTK:
                    ViewModel.UserAuthenticatedCallback = async () => await Navigation.PushModalAsync(new MainPage(), animated: true);
                    break;
                default:
                    ViewModel.UserAuthenticatedCallback = async () => await Navigation.PopModalAsync(animated: true);
                    break;
            }
            
            BindingContext = ViewModel;

		    SizeChanged += (sender, args) =>
		    {
		        string visualState = Width > Height ? "Landscape" : "Portrait";
		        VisualStateManager.GoToState(LoginPageLayout, visualState);
		        VisualStateManager.GoToState(LoginPageEntryLayout, visualState);
		    };
        }

        LoginViewModel ViewModel { get; } = new LoginViewModel();
	}
}