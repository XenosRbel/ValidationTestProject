using System;
using ValidationTestProject.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ValidationTestProject
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			var navigationPage = new NavigationPage(new MainPage());
			MainPage = navigationPage.RootPage;

			//MainPage.Navigation.PushModalAsync(new Sample2Page(), false);
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
