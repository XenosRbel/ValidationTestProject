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
	public partial class Sample5Page : ContentPage
	{
		public Sample5Page()
		{
			InitializeComponent();

			var viewModel = new Sample5ViewModel();
			BindingContext = viewModel;
		}
	}
}