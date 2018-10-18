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
            Locator.CurrentMutable.RegisterLazySingleton(() => new DummyChatService(), typeof(IChatService));

            switch (Device.RuntimePlatform)
            {
                case Device.macOS:
                    MainPage = new NavigationPage(new LoginPage());
                    break;
                default:
                    MainPage = new NavigationPage(new MainPage());
                    break;
            }
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
