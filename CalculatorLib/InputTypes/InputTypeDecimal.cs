namespace CalculatorLib.InputTypes;

public class InputTypeDecimal: IParsableInput<InputTypeDecimal>
{
    private InputTypeDecimal(decimal value) => Value = value;
    
    public decimal Value {
        get;
    }
    
    public static InputTypeDecimal Parse(string input)
    {
        if (!decimal.TryParse(input, out var number)) throw new FormatException($"'{input}' is not a valid number.");

        return new InputTypeDecimal(number);
    }
    
    public static decimal GetMaxValue()
    {
        return decimal.MaxValue;
    }
    
    public static decimal GetMinValue()
    {
        return decimal.MinValue;
    }
}