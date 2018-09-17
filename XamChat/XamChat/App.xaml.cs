using System;
using Splat;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamChat.Services;
using XamChat.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamChat
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Locator.CurrentMutable.RegisterLazySingleton(() => new DummyUserService(), typeof(IUserService));

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
