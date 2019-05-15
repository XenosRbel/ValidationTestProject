using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace ValidationTestProject.Helpers
{
	public class ObservableObject<T> : INotifyPropertyChanged
	{
		private T _value;

		public T Value
		{
			get => _value;
			set
			{
				if (_value != null && _value.Equals(value)) return;

				_value = value;
				OnPropertyChanged();
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
