using CalculatorLib.Constants;
using CalculatorLib.InputTypes;


namespace CalculatorLib
{
    public static class Calculator
    {
        public static decimal Calculate(InputTypeDecimal num1, InputTypeDecimal num2, InputTypeOperand inputTypeOperand)
        {
            return inputTypeOperand.Apply(num1, num2);
        }

        // INPUT VALUES LIMITATIONS
        public static decimal GetMaxDecimalValue()
        {
            return DecimalConstants.GetMaxDecimalValue();
        }

        public static decimal GetMinDecimalValue()
        {
            return DecimalConstants.GetMinDecimalValue();
        }

        public static string GetOperandValues()
        {
            return InputTypeOperand.GetValues();
        }
    }
}