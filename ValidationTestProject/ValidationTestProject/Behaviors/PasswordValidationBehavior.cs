using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ValidationTestProject.Behaviors
{
	internal class PasswordValidationBehavior : Behavior<Entry>
	{
		protected override void OnAttachedTo(Entry bindable)
		{
			base.OnAttachedTo(bindable);
			bindable.TextChanged += OnBindableTextChanged;
		}

		private void OnBindableTextChanged(object sender, TextChangedEventArgs e)
		{
			var entry = (Entry) sender;
			if (string.IsNullOrWhiteSpace(e.NewTextValue))
			{
				entry.BackgroundColor = Color.Red;
				return;
			}

			entry.BackgroundColor = Color.Default;
		}

		protected override void OnDetachingFrom(Entry bindable)
		{
			base.OnDetachingFrom(bindable);
			bindable.TextChanged -= OnBindableTextChanged;
		}
	}
}
