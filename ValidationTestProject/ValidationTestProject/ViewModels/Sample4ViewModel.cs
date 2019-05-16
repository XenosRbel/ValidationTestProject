using System.IO;
using System.Runtime.CompilerServices;
using ValidationTestProject.Model;
using Xamarin.Forms;

namespace ValidationTestProject.ViewModels
{
	internal class Sample4ViewModel : BaseViewModel
	{
		private string _userName;
		private string _userPassword;
		private string _userPasswordConfirm;
		private string _errorMessage;

		public Command SubmitCommand { get; set; }

		public string ErrorMessage
		{
			get => _errorMessage;
			set => SetProperty(ref _errorMessage, value);
		}

		public string UserName
		{
			get => _userName; 
			set => SetProperty(ref _userName, value);
		}

		public string UserPassword
		{
			get => _userPassword;
			set => SetProperty(ref _userPassword, value);
		}

		public string UserPasswordConfirm
		{
			get => _userPasswordConfirm;
			set => SetProperty(ref _userPasswordConfirm, value);
		}

		private User _userDataModel;

		public Sample4ViewModel()
		{
			_userDataModel = new User();
			SubmitCommand = new Command(OnSubmit);
			this.PropertyChanged += Sample4ViewModel_PropertyChanged;
		}

		private void Sample4ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			var type = sender.GetType();
			var propertyName = e.PropertyName;
		}

		private void OnSubmit()
		{
			UserName += $"1";
		}
	}
}