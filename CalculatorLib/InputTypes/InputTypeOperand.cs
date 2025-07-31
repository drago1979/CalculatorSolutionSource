namespace CalculatorLib.InputTypes
{
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

        public static InputTypeOperand Parse(string input)
        {
            if (!Operations.ContainsKey(input))
            {
                throw new FormatException($"String '{input}' is not valid symbol for mathematical operation");
            }
            
            return new InputTypeOperand(input);
        }
        
        internal decimal Apply(InputTypeDecimal num1, InputTypeDecimal num2)
        {
            return Operations[_symbol](num1.Value, num2.Value);
        }

        internal static string GetValues()
        {
            return string.Join(',', Operations.Keys);
        }
    }
}