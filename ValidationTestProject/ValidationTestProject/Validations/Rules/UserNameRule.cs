using ValidationTestProject.Helpers;
using ValidationTestProject.Model;

namespace ValidationTestProject.Validations.Rules
{
	//public class UserDataRule<T> : IBaseValidationRule<T>
	//{
	//	public string ValidationMessage { get; set; }
	//	public bool Check(T value)
	//	{
	//		if (value is User userData)
	//		{
	//			return !string.IsNullOrWhiteSpace(userData.UserName) &&
	//				!string.IsNullOrWhiteSpace(userData.Password) &&
	//				!string.IsNullOrWhiteSpace(userData.ConfirmPassword) &&
	//				string.Equals(userData.Password, userData.ConfirmPassword);
	//		}

	//		return false;
	//	}
	//}

	public class IsPasswordNotNullOrWhiteSpace : IBaseValidationRule<User>
	{
		public string PropertyName { get; set; }
		public string ValidationMessage { get; set; }
		public bool Check(User value)
		{
			return !string.IsNullOrWhiteSpace(value.Password);
		}
	}

	public class IsConfirmPasswordNotNullOrWhiteSpace : IBaseValidationRule<User>
	{
		public string PropertyName { get; set; }
		public string ValidationMessage { get; set; }
		public bool Check(User value)
		{
			return !string.IsNullOrWhiteSpace(value.ConfirmPassword);
		}
	}

	public class IsUserNameNotNullOrWhiteSpace : IBaseValidationRule<User>
	{
		public string PropertyName { get; set; }
		public string ValidationMessage { get; set; }
		public bool Check(User value)
		{
			return !string.IsNullOrWhiteSpace(value.UserName);
		}
	}

	public class IsPasswordMatching : IBaseValidationRule<User>
	{
		public string PropertyName { get; set; }
		public string ValidationMessage { get; set; }
		public bool Check(User value)
		{
			return string.Equals(value.Password, value.ConfirmPassword);
		}
	}
}
