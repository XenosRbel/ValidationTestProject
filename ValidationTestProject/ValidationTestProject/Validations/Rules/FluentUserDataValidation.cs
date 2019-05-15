using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using ValidationTestProject.Model;

namespace ValidationTestProject.Validations.Rules
{
	public class FluentUserDataValidation : AbstractValidator<User>
	{
		public FluentUserDataValidation()
		{
			RuleFor(x => x.UserName).NotNull().NotEmpty();
			RuleFor(x => x.Password).NotNull().NotEmpty();
			RuleFor(x => x.ConfirmPassword).NotNull().NotEmpty().Equal(x => x.Password);
		}
	}
}
