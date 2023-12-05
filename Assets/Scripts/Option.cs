public class Option<T>
{
	public static Option<T> None => default;

	private readonly bool _hasValue;
	private readonly T _value;

	public Option(T value)
	{
		_value = value;
		_hasValue = value is {};
	}

	public bool HasValue(out T value)
	{
		value = _value;
		return _hasValue;
	}
}
