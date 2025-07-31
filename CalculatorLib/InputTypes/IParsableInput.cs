namespace CalculatorLib.InputTypes;

// public interface IParsableInput
// {
//     public static abstract IParsableInput Parse(string input);
// }

public interface IParsableInput<TSelf> where TSelf : IParsableInput<TSelf>
{
    static abstract TSelf Parse(string input);
}