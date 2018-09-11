using System;
using HymnPlayer.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace HymnPlayer
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

		    //MainPage = new PlayerView();
		    //MainPage = new NavigationPage(new HymnsList());

		    var navPage = new NavigationPage(new HymnsList());
		    MainPage = navPage;
		}

		protected override void OnStart ()
		{
            // Handle when your app starts
		    //NavigationPage.SetHasNavigationBar(this, false);
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
