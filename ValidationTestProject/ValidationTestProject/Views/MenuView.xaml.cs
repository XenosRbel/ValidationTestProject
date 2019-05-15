using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationTestProject.ViewModels.Menu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ValidationTestProject.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuView : ContentView
	{
		public MenuView()
		{
			InitializeComponent();
			var viewModel = new MenuViewModel(this.Navigation);
			BindingContext = viewModel;
		}
	}
}