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
		    ViewModel.UserAuthenticatedCallback = async () => await Navigation.PopModalAsync(animated: true);
		    BindingContext = ViewModel;
		}

        LoginViewModel ViewModel { get; } = new LoginViewModel();
	}
}