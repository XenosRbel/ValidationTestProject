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
	public partial class Sample3Page : ContentPage
	{
		public Sample3Page()
		{
			InitializeComponent();

			var viewModel = new Sample3ViewModel(this);
			BindingContext = viewModel;
		}
	}
}