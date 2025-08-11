using Shared.Base;
using Shared.Localization.Shared;

namespace Shared.Interfaces;

/// <summary>
/// Defines a mechanism to terminate the application gracefully.
/// </summary>
public interface IApplicationTerminator
{
    /// <summary>
    /// Terminates the application  and provides the user with a final message.
    /// </summary>
    public void Terminate(UserInterface userInterface, UserMessages userMessages);
}