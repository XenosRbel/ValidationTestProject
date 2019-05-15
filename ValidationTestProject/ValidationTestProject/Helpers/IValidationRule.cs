namespace ValidationTestProject.Helpers
{
	public interface IBaseValidationRule<in T>
	{
		string ValidationMessage { get; set; }
		bool Check(T value);
	}
}