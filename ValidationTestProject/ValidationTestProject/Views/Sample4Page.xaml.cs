using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationTestProject.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ValidationTestProject.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Sample4Page : ContentPage
	{
		public Sample4Page()
		{
			InitializeComponent();

			var viewModel = new Sample4ViewModel();
			BindingContext = viewModel;
		}
	}
}