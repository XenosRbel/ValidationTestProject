using System.Collections.Generic;
using System.Linq;

namespace ValidationTestProject.Helpers
{
	public class ValidatableObject<T> : ObservableObject<T>, IValidity
	{
		public List<IBaseValidationRule<T>> Validations => _validations;

		public List<string> Errors
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
		
		public ValidatableObject()
		{
			_errors = new List<string>();
			_isValid = false;
			_validations = new List<IBaseValidationRule<T>>();
		}

		public bool Validate()
		{
			Errors.Clear();

			var errors = _validations.Where(item => !item.Check(Value))
				.Select(item => item.ValidationMessage);

			Errors = errors.ToList();
			IsValid = !Errors.Any();

			return IsValid;
		}

		private List<string> _errors;
		private bool _isValid;
		private readonly List<IBaseValidationRule<T>> _validations;
	}
}