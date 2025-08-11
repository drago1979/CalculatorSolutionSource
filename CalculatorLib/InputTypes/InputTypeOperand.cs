namespace CalculatorLib.InputTypes
{
    /// Represents a mathematical operation input type used in calculations.
    /// Defines operations such as addition, subtraction, multiplication, or division,
    /// as well as methods to validate and apply these operations.
    public readonly record struct InputTypeOperand: IParsableInput<InputTypeOperand> // todo: confirm adequate struct; what about others?
    {
        private readonly string _symbol;

        private static readonly Dictionary<string, Func<decimal, decimal, decimal>> Operations = new()
        {
            ["+"] = (a, b) => a + b,
            ["-"] = (a, b) => a - b,
            ["*"] = (a, b) => a * b,
            ["/"] = (a, b) => a / b,
        };

        private InputTypeOperand(string symbol)
        {
            _symbol = symbol;
        }

        /// Parses a string input into an instance of InputTypeOperand.
        /// Validates whether the input matches a supported mathematical operation symbol.
        /// <exception cref="FormatException">Thrown when the input string does not represent a valid operation symbol.</exception>
        public static InputTypeOperand Parse(string input)
        {
            if (!Operations.ContainsKey(input))
            {
                throw new FormatException($"String '{input}' is not valid symbol for mathematical operation");
            }

            return new InputTypeOperand(input);
        }
        
        /// Executes the mathematical operation (e.g., addition, subtraction, multiplication, division)
        internal decimal Apply(InputTypeDecimal num1, InputTypeDecimal num2)
        {
            return Operations[_symbol](num1.Value, num2.Value);
        }

        /// Retrieves a comma-separated string containing all supported mathematical operation symbols.
        internal static string GetValues()
        {
            return string.Join(',', Operations.Keys);
        }
    }
}