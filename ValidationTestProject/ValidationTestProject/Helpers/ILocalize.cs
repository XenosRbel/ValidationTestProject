using System.Globalization;

namespace ValidationTestProject.Helpers
{
	public interface ILocalize
	{
		CultureInfo GetCurrentCultureInfo();
		void SetLocale(CultureInfo ci);
	}
}