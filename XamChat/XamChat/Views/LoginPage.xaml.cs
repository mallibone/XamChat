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

		    SizeChanged += (sender, args) =>
		    {
		        string visualState = Width > Height ? "Landscape" : "Portrait";
		        VisualStateManager.GoToState(LoginPageLayout, visualState);
		        VisualStateManager.GoToState(LoginPageEntryLayout, visualState);

		        //foreach (View child in menuStack.Children)
		        //{
		        //    VisualStateManager.GoToState(child, visualState);
		        //}
		    };
        }

        LoginViewModel ViewModel { get; } = new LoginViewModel();
	}
}