using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationTestProject.ViewModels;
using ValidationTestProject.ViewModels.MainPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ValidationTestProject.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Sample2Page : ContentPage
	{
		public Sample2Page()
		{
			InitializeComponent();

			var viewModel = new Sample2ViewModel();
			BindingContext = viewModel;
		}
	}
}