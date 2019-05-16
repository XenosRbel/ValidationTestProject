using FluentValidation;
using ValidationTestProject.Helpers;
using ValidationTestProject.Model;
using ValidationTestProject.Resext;
using ValidationTestProject.Validations.Rules;
using Xamarin.Forms;

namespace ValidationTestProject.ViewModels
{
	internal class Sample3ViewModel : BaseViewModel
	{
		private readonly IValidator _validator;
		private Page _page;
		public ObservableObject<User> UserData { get; set; }
		public Command CheckUserData { get; set; }

		public Sample3ViewModel(Page page)
		{
			UserData = new ObservableObject<User>();
			UserData.Value = new User();

			CheckUserData = new Command(Validate);
			_validator = new FluentUserDataValidation();
			_page = page;
		}

		private void Validate()
		{
			var result = _validator.Validate(UserData.Value);

			if (result.IsValid)
			{
				_page.DisplayAlert("Validation", "Validation Success..!!", "OK");
			}
			else
			{
				_page.DisplayAlert("Validation", $"{result?.Errors[0]}\t{AppResources.errorUserNameMessage}", "OK");
			}
		}
	}
}