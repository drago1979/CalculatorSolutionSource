namespace CalculatorLib.Interfaces;

/// <summary>
/// Defines a generic interface for parsing input strings into specific types.
/// </summary>
public interface IParser<T> // TODO: The type parameter 'T' could be declared as covariant
{
    /// <summary>
    /// Parses the given input string and converts it into the desired output type.
    /// </summary>
    public T Parse(string input);
}