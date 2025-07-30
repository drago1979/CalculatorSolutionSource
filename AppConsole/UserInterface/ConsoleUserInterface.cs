using static System.Console;

namespace AppConsole.UserInterface;

public class ConsoleUserInterface : Shared.Base.UserInterface
{
    private const string ErrorMessagePrefix = "!!!! ";

    private const ConsoleColor SuccessColor = ConsoleColor.Green;
    private const ConsoleColor ErrorColor = ConsoleColor.Red;

    public override string GetInput()
    {
        return ReadLine()!;
    }

    public override void Respond(string message)
    {
        ForegroundColor = SuccessColor;
        WriteLine(message);
    }

    public override void Respond(Exception e)
    {
        ForegroundColor = ErrorColor;
        WriteLine(ErrorMessagePrefix + e.Message);
    }
}