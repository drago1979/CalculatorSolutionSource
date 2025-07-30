namespace CalculatorLib.Interfaces;

public interface IParser<T> // TODO: The type parameter 'T' could be declared as covariant
{
    public T Parse(string input);
}