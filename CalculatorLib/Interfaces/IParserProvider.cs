namespace CalculatorLib.Interfaces;

/// <summary>
/// Provides a mechanism to retrieve a parser instance for a specified type.
/// </summary>
public interface IParserProvider
{
    /// <summary>
    /// Retrieves an instance of a parser for the specified type.
    /// </summary>
    public IParser<T> GetParser<T>();
}