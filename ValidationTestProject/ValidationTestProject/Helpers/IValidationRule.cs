namespace ValidationTestProject.Helpers
{
	public interface IBaseValidationRule<in T>
	{
		string PropertyName { get; set; }
		string ValidationMessage { get; set; }
		bool Check(T value);
	}
}