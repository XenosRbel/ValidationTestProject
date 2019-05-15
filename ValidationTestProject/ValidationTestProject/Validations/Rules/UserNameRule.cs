using ValidationTestProject.Helpers;
using ValidationTestProject.Model;

namespace ValidationTestProject.Validations.Rules
{
	public class UserDataRule<T> : IBaseValidationRule<T>
	{
		public string ValidationMessage { get; set; }
		public bool Check(T value)
		{
			if (value is User userData)
			{
				var paswdConfirmResultCheck = !string.IsNullOrWhiteSpace(userData.ConfirmPassword);
				var userNameResultCheck = !string.IsNullOrWhiteSpace(userData.UserName);
				var paswdResultCheck = !string.IsNullOrWhiteSpace(userData.Password);
				var twinPaswd = string.Equals(userData.Password, userData.ConfirmPassword);

				if (twinPaswd)
				{
					if (paswdConfirmResultCheck && userNameResultCheck && paswdResultCheck)
					{
						return true;
					}

					return false;
				}
			}

			return false;
		}
	}
}
