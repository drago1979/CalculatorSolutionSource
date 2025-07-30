using CalculatorLib.InputTypes;
using CalculatorLib.Interfaces;

namespace CalculatorLib.Services.Parsers;

public class OperandParser:IParser<Operand>
{
    public Operand Parse(string s)
    {
        return Operand.Parse(s);
    }
}