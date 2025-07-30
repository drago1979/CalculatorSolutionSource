using CalculatorLib.Constants;
using CalculatorLib.InputTypes;
using CalculatorLib.Interfaces;
using CalculatorLib.Services.Parsers;

namespace CalculatorLib
{
    public static class Calculator
    {
        public static decimal Calculate(decimal num1, decimal num2, Operand operand)
        {
            return operand.Apply(num1, num2);
        }

        // INPUT VALUES LIMITATIONS
        public static decimal GetMaxDecimalValue()
        {
            return  DecimalConstants.GetMaxDecimalValue();
        }
        
        public static decimal GetMinDecimalValue()
        {
            return DecimalConstants.GetMinDecimalValue();
        }

        public static string GetOperandValues()
        {
            return Operand.GetValues();
        }

        // PARSE
        public static decimal ParseDecimal(string s)
        {
            return GetDecimalParser().Parse(s);
        }
    
        public static Operand ParseOperand(string s)
        {
            return GetOperandParser().Parse(s);
        }

        // GET PARSERS
        public static IParser<decimal> GetDecimalParser()
        {
            return new DecimalParser();
        }
        
        public static IParser<Operand> GetOperandParser()
        {
            return new OperandParser();
        }
    }
}