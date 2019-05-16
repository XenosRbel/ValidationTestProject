using System;
using System.Threading;
using ValidationTestProject.Helpers;
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

			var navigationPage = new NavigationPage(new Sample4Page());
			MainPage = navigationPage.RootPage;
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
