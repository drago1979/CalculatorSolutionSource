namespace CalculatorLib.InputTypes;

public interface IParsableInput<TSelf> where TSelf : IParsableInput<TSelf>
{
    static abstract TSelf Parse(string input);
}