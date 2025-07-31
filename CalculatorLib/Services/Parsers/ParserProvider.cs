using CalculatorLib.InputTypes;
using CalculatorLib.Interfaces;

namespace CalculatorLib.Services.Parsers;

public class ParserProvider: IParserProvider
{
    public IParser<T> GetParser<T>()
    {
        if (typeof(T) == typeof(decimal)) return (IParser<T>)new DecimalParser();
        
        if (typeof(T) == typeof(Operand)) return (IParser<T>)new OperandParser();
        
        throw new InvalidOperationException($"No parser registered for type {typeof(T)}");
    }
}