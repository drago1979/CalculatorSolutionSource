using Shared.Interfaces;
using Shared.Localization.Shared;

namespace AppConsole.AppTerminator;

public class ConsoleApplicationTerminator:  IApplicationTerminator
{
    public void Terminate(Shared.Base.UserInterface userInterface, UserMessages userMessages)
    {
        userInterface.Respond(userMessages.GetMessageUserAbortedExecution());
        
        Environment.Exit(0);
    }
}