using System;
using System.Collections.Generic;
using System.Text;
using ValidationTestProject.Views;
using Xamarin.Forms;

namespace ValidationTestProject.ViewModels.Menu
{
	internal class MenuViewModel : BaseViewModel
	{
		private INavigation _navigation;
		public Command Navigate1 { get; set; }
		public Command Navigate2 { get; set; }
		public Command Navigate3 { get; set; }

		public MenuViewModel(INavigation navigation)
		{
			_navigation = navigation;
			Navigate1 = new Command(Sample1);
			Navigate2 = new Command(Sample2);
			Navigate3 = new Command(Sample3);
		}

		private void Sample3()
		{
			_navigation.PushModalAsync(new Sample3Page());
		}

		private void Sample2()
		{
			_navigation.PushModalAsync(new Sample2Page());
		}

		private void Sample1()
		{
			_navigation.PushModalAsync(new ValidationTestProject.MainPage());
		}
	}
}
