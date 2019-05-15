using ValidationTestProject.Helpers;
using ValidationTestProject.Model;
using ValidationTestProject.Validations.Rules;
using Xamarin.Forms;

namespace ValidationTestProject.ViewModels.MainPage
{
	internal class MainPageViewModel : BaseViewModel
	{
		public ValidatableObject<User> UserDataValidatableObject { get; set; }
		public Command CheckUserData { get; set; }

		public MainPageViewModel()
		{
			UserDataValidatableObject = new ValidatableObject<User>();
			UserDataValidatableObject.Value = new User();

			CheckUserData = new Command(Validate);

			UserDataValidatableObject.Validations.Add(new UserDataRule<User>{ValidationMessage = "User isn't valid"});
		}

		private void Validate()
		{
			UserDataValidatableObject.Validate();
		}
	}
}
