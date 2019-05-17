using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using ValidationTestProject.Model;
using ValidationTestProject.Resext;
using Xamarin.Forms;
using TypeConverter = System.ComponentModel.TypeConverter;

namespace ValidationTestProject.ViewModels
{
	internal class Sample4ViewModel : BaseViewModel
	{
		private const string modelErrorMessage = "Model isn't valid";

		private string _userName;
		private string _userPassword;
		private string _userPasswordConfirm;
		private string _errorMessage;
		private bool _isUserNameValid;
		private User _userDataModel;
		private bool _isValid;
		
		public Command SubmitCommand { get; private set; }

		public bool IsValid
		{
			get => _isValid;
			set => SetProperty(ref _isValid, value);
		} 

		public bool IsUserNameValid
		{
			get => _isUserNameValid;
			set => SetProperty(ref _isUserNameValid, value);
		}

		public string ErrorMessage
		{
			get => _errorMessage;
			set => SetProperty(ref _errorMessage, value);
		}

		public string UserName
		{
			get => _userName;
			set
			{
				SetProperty(ref _userName, value);
				Validate();
			}
		}

		public string UserPassword
		{
			get => _userPassword;
			set
			{
				SetProperty(ref _userPassword, value); 
				Validate();
			}
		}

		public string UserPasswordConfirm
		{
			get => _userPasswordConfirm;
			set
			{
				SetProperty(ref _userPasswordConfirm, value);
				Validate();
			}
		}

		public Sample4ViewModel()
		{
			_userDataModel = new User();
			SubmitCommand = new Command(OnSubmit);
			PropertyChanged += OnPropertyChanged;
		}

		private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			//var type = sender.GetType();
			//var propertyInfo = type.GetProperty(e.PropertyName);
			//var propertyValue = Convert.ChangeType(propertyInfo.GetValue(sender), propertyInfo.PropertyType);

			//if (e.PropertyName == nameof(ErrorMessage)) return;

			//if (propertyValue is string obj && 
			//    !string.IsNullOrWhiteSpace(obj))
			//{
			//	ErrorMessage = $"{e.PropertyName}:{modelErrorMessage}";
			//}
			//else
			//{
			//	ErrorMessage = string.Empty;
			//}
		}

		private void OnSubmit()
		{
			UserName += 1;
		}

		private void Validate()
		{
			IsValid = !string.IsNullOrWhiteSpace(UserName) &&
			          !string.IsNullOrWhiteSpace(UserPassword) &&
			          !string.IsNullOrWhiteSpace(UserPasswordConfirm) &&
			          string.Equals(UserPassword, UserPasswordConfirm);

			ErrorMessage = IsValid ? string.Empty : $"{modelErrorMessage}";
		}
	}
}