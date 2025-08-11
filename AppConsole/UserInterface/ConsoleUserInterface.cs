using static System.Console;

namespace AppConsole.UserInterface;

///
public class ConsoleUserInterface : Shared.Base.UserInterface
{
    private const string MessagePrefixSuffix = "--------------------------";
    private const string NewLineSymbol = "\r\n";
    
    private const string ErrorMessagePrefix = "!!!! ";

    private const ConsoleColor SuccessColor = ConsoleColor.Green;
    private const ConsoleColor ErrorColor = ConsoleColor.Red;

    /// <summary>
    /// Reads and returns input from the console.
    /// </summary>
    public override string GetInput()
    {
        return ReadLine()!;
    }
    
    /// <param name="message">The message to be displayed to the user.</param>
    public override void Respond(string message)
    {
        ForegroundColor = SuccessColor;
        WriteLine(GetMessagePrefix() + message + GetMessageSuffix());
    }
    
    /// <param name="e">Exception to use the message.</param>
    public override void Respond(Exception e)
    {
        ForegroundColor = ErrorColor;
        WriteLine(GetMessagePrefix() + GetErrorString() + e.Message + GetMessageSuffix());
    }
    
    private static string GetMessagePrefix() => MessagePrefixSuffix + NewLineSymbol;
    
    private static string GetMessageSuffix() => NewLineSymbol + MessagePrefixSuffix;
    
    private static string GetErrorString() => ErrorMessagePrefix + NewLineSymbol;
}