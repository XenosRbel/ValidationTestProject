using System;
using System.Collections.Generic;
using System.Text;
using ValidationTestProject.Helpers;
using ValidationTestProject.Model;

namespace ValidationTestProject.ViewModels
{
	internal class Sample2ViewModel : BaseViewModel
	{
		public ObservableObject<User> UserData { get; set; }

		public Sample2ViewModel()
		{
			UserData = new ObservableObject<User>();
			UserData.Value = new User();
		}
	}
}
