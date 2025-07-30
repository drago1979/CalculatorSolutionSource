using AppConsole.AppTerminator;
using AppConsole.UserInterface;
using Shared.AppLogic;
using Shared.Localization.Factory;


namespace AppConsole;

public static class Program
{
    private static void Main()
    {
        // Following would be automatically injected:
        //----  1) Depends if console or (eg) web app
        var ui = new ConsoleUserInterface();
        var terminator = new ConsoleApplicationTerminator();
        
        //---- 2) Just for fun (left the ability to use different factory later)
        // var messagesFactory = new UserMessagesFactoryDictionaryBased();
        var messagesFactory = new UserMessagesFactoryDictionaryBased();
        
        var app = new CalculatorApp(ui, terminator, messagesFactory);
        app.Run();
    }
}