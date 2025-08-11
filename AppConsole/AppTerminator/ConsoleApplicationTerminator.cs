using Shared.Interfaces;
using Shared.Localization.Shared;

namespace AppConsole.AppTerminator;

///
public class ConsoleApplicationTerminator:  IApplicationTerminator
{
    /// Terminates the application by displaying a message and exiting the process.
    public void Terminate(Shared.Base.UserInterface userInterface, UserMessages userMessages)
    {
        userInterface.Respond(userMessages.GetMessageUserAbortedExecution());
        
        Environment.Exit(0);
    }
}