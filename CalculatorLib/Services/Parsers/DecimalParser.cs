using CalculatorLib.Interfaces;

namespace CalculatorLib.Services.Parsers;

public class DecimalParser: IParser<decimal>
{
    public decimal Parse(string s)
    {
        return Convert.ToDecimal(s);
    }
}