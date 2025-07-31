namespace CalculatorLib.Interfaces;

public interface IParserProvider
{
    public IParser<T> GetParser<T>();
}