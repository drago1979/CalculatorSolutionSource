namespace CalculatorLib.InputTypes;

/// Represents a decimal input type used in calculations, capable of parsing string input into a decimal value.
public class InputTypeDecimal: IParsableInput<InputTypeDecimal>
{
    private InputTypeDecimal(decimal value) => Value = value;
    
    ///
    public decimal Value {
        get;
    }

    /// Parses a string representation into an instance of InputTypeDecimal.
    public static InputTypeDecimal Parse(string input)
    {
        if (!decimal.TryParse(input, out var number)) throw new FormatException($"'{input}' is not a valid number.");

        return new InputTypeDecimal(number);
    }

    /// Retrieves the maximum representable value for the decimal type.
    public static decimal GetMaxValue()
    {
        return decimal.MaxValue;
    }

    /// Retrieves the minimum representable value for the decimal type.
    public static decimal GetMinValue()
    {
        return decimal.MinValue;
    }
}