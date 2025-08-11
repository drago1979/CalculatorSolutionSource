using CalculatorLib.InputTypes;


namespace CalculatorLib
{
    /// A class providing core calculator functionality including arithmetic operations and input value constraints.
    public static class Calculator
    {
        /// Performs a calculation using two numeric inputs and an operation defined by the given operand.
        /// The operation is applied to the numeric inputs using their defined rules.
        /// <param name="num1">The first numeric input of type InputTypeDecimal.</param>
        /// <param name="num2">The second numeric input of type InputTypeDecimal.</param>
        /// <param name="inputTypeOperand">The mathematical operation to apply, represented as an InputTypeOperand.</param>
        /// <return>The result of the calculation as a decimal.</return>
        public static decimal Calculate(InputTypeDecimal num1, InputTypeDecimal num2, InputTypeOperand inputTypeOperand)
        {
            return inputTypeOperand.Apply(num1, num2);
        }

        // INPUT VALUES LIMITATIONS
        
        /// Retrieves the maximum representable value for the decimal type.
        /// <return>The maximum value of the decimal type, represented as a decimal.</return>
        public static decimal GetMaxDecimalValue()
        {
            return InputTypeDecimal.GetMaxValue();
        }

        /// Retrieves the minimum representable value for the decimal type.
        /// <return>The minimum value of the decimal type, represented as a decimal.</return>
        public static decimal GetMinDecimalValue()
        {
            return InputTypeDecimal.GetMinValue();
        }

        /// Retrieves a string representation of all supported mathematical operations.
        /// The returned string consists of operation symbols separated by commas.
        /// <return>A comma-separated string of all valid operation symbols.</return>
        public static string GetOperandValues()
        {
            return InputTypeOperand.GetValues();
        }
    }
}