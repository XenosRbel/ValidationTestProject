using System.Linq;
using ValidationTestProject.Helpers;
using ValidationTestProject.Model;
using ValidationTestProject.Validations.Rules;
using Xamarin.Forms;

namespace ValidationTestProject.ViewModels
{
	internal class Sample5ViewModel : BaseViewModel
	{
		private bool _isValid;
		private string _errorMessage;
		private string _userNameErrorMessage;
		private string _userPasswordErrorMessage;
		private string _userPasswordConfirmErrorMessage;

		private string _userName;
		private string _userPassword;
		private string _userPasswordConfirm;

		public bool IsValid
		{
			get => _isValid;
			set => SetProperty(ref _isValid, value);
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

		public Command SubmitCommand { get; private set; }

		public string UserNameErrorMessage
		{
			get => _userNameErrorMessage;
			set => SetProperty(ref _userNameErrorMessage, value);
		}

		public string UserPasswordErrorMessage
		{
			get => _userPasswordErrorMessage;
			set => SetProperty(ref _userPasswordErrorMessage, value);
		}

		public string UserPasswordConfirmErrorMessage
		{
			get => _userPasswordConfirmErrorMessage;
			set => SetProperty(ref _userPasswordConfirmErrorMessage, value);
		}

		public Sample5ViewModel()
		{
			SubmitCommand = new Command(Execute, () => IsValid);
		}

		private void Execute()
		{
			UserName += 1;
		}

		private void Validate()
		{
			var userValidatable= new ValidableObject<User>
			{
				Value = new User
				{
					UserName = UserName,
					ConfirmPassword = UserPasswordConfirm,
					Password = UserPassword
				}
			};

			userValidatable.Validations.Add(new IsPasswordMatching{
				ValidationMessage = "Password isn't confirmed",
				PropertyName = $"CommonPassword"
			});

			userValidatable.Validations.Add(new IsPasswordNotNullOrWhiteSpace
			{
				ValidationMessage = "Password isn't valid",
				PropertyName = nameof(UserPasswordErrorMessage)
			});

			userValidatable.Validations.Add(new IsConfirmPasswordNotNullOrWhiteSpace
			{
				ValidationMessage = "Confirm password isn't valid",
				PropertyName = nameof(UserPasswordConfirmErrorMessage)
			});

			userValidatable.Validations.Add(new IsUserNameNotNullOrWhiteSpace
			{
				ValidationMessage = "User name isn't valid",
				PropertyName = nameof(UserNameErrorMessage)
			});
		
			IsValid = userValidatable.Validate();

			UserPasswordErrorMessage = UserPasswordConfirmErrorMessage = UserNameErrorMessage = string.Empty; 
			foreach (var VARIABLE in userValidatable.Errors)
			{
				switch (VARIABLE.Key)
				{
					case nameof(UserPasswordErrorMessage):
						UserPasswordErrorMessage += $" {VARIABLE.Value};";
						break;
					case nameof(UserPasswordConfirmErrorMessage):
						UserPasswordConfirmErrorMessage += $" {VARIABLE.Value};";
						break;
					case "CommonPassword":
						UserPasswordErrorMessage += $" {VARIABLE.Value};";
						UserPasswordConfirmErrorMessage += $" {VARIABLE.Value};";
						break;
					case nameof(UserNameErrorMessage):
						UserNameErrorMessage += $" {VARIABLE.Value};";
						break;
				}
			}

			ErrorMessage = string.Join("; ", userValidatable.Errors.Values);
		}
	}
}