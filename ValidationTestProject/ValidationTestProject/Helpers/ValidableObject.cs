using System.Collections.Generic;
using System.Linq;

namespace ValidationTestProject.Helpers
{
	public class ValidableObject<T> : ObservableObject<T>, IValidity
	{
		public List<IBaseValidationRule<T>> Validations => _validations;

		public Dictionary<string, string> Errors
		{
			get => _errors;
			set
			{
				_errors = value;
				OnPropertyChanged();
			}
		}

		public bool IsValid
		{
			get => _isValid;
			set
			{
				_isValid = value;
				OnPropertyChanged();
			}
		}
		
		public ValidableObject()
		{
			_errors = new Dictionary<string, string>();
			_isValid = false;
			_validations = new List<IBaseValidationRule<T>>();
		}

		public bool Validate()
		{
			Errors.Clear();

			var errors = _validations.Where(item => !item.Check(Value)).ToDictionary(x => x.PropertyName, y => y.ValidationMessage);

			Errors = errors;
			IsValid = !Errors.Any();

			return IsValid;
		}

		private Dictionary<string, string> _errors;
		private bool _isValid;
		private readonly List<IBaseValidationRule<T>> _validations;
	}
}