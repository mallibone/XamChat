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
                case "Ooui":
                    ViewModel.UserAuthenticatedCallback = async () => await Navigation.PopAsync(animated: true);
                    break;
                default:
                    ViewModel.UserAuthenticatedCallback = async () => await Navigation.PopModalAsync(animated: true);
                    break;
		    }
		    BindingContext = ViewModel;
		}

        LoginViewModel ViewModel { get; } = new LoginViewModel();
	}
}