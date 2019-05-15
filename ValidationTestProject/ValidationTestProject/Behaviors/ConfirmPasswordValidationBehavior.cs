using System;
using ValidationTestProject.ViewModels;
using ValidationTestProject.ViewModels.MainPage;
using Xamarin.Forms;

namespace ValidationTestProject.Behaviors
{
	internal class ConfirmPasswordValidationBehavior : Behavior<Entry>
	{
		public static readonly BindableProperty TextProperty =
			BindableProperty.Create(nameof(Text),
				typeof(string),
				typeof(ConfirmPasswordValidationBehavior),
				string.Empty,
				BindingMode.TwoWay);

		public string Text
		{
			get => (string) GetValue(TextProperty);
			set => SetValue(TextProperty, value);
		}

		protected override void OnAttachedTo(Entry bindable)
		{
			base.OnAttachedTo(bindable);
			bindable.TextChanged += OnBindableTextChanged;
		}

		private void OnBindableTextChanged(object sender, TextChangedEventArgs e)
		{
			var entry = (Entry)sender;
			var isValid = string.Equals(e.NewTextValue, Text);
			var context = (Sample2ViewModel) entry.BindingContext;

			if (string.IsNullOrWhiteSpace(e.NewTextValue))
			{
				entry.BackgroundColor = Color.Red;

				return;
			}

			if (!isValid)
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