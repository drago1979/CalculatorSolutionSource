namespace CalculatorLib.InputTypes;

/// A contract for parsing string inputs into specific input types.
public interface IParsableInput<TSelf> where TSelf : IParsableInput<TSelf>
{
    /// Parses a string representation into a specific type implementing IParsableInput.
    /// <returns>An instance of the specific type created from the parsed input.</returns>
    /// <exception cref="FormatException"></exception>
    static abstract TSelf Parse(string input);
}