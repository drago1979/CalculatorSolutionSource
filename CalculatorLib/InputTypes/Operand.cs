namespace CalculatorLib.InputTypes
{
    public readonly record struct Operand // todo: confirm adequate struct; what about others?
    {
        private readonly string _symbol;

        private static readonly Dictionary<string, Func<decimal, decimal, decimal>> Operations = new()
        {
            ["+"] = (a, b) => a + b,
            ["-"] = (a, b) => a - b,
            ["*"] = (a, b) => a * b,
            ["/"] = (a, b) => a / b,
        };

        private Operand(string symbol)
        {
            _symbol = symbol;
        }

        internal static Operand Parse(string input)
        {
            if (!Operations.ContainsKey(input))
            {
                throw new FormatException($"String '{input}' is not valid symbol for mathematical operation");
            }

            return new Operand(input);
        }

        internal decimal Apply(decimal num1, decimal num2)
        {
            return Operations[_symbol](num1, num2);
        }

        internal static string GetValues()
        {
            return string.Join(',', Operations.Keys);
        }
    }
}