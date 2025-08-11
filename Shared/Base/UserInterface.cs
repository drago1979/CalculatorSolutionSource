namespace Shared.Base;

/// <summary>
/// Represents an abstract base class for user interface interactions.
/// </summary>
public abstract class UserInterface
{
    ///
    public abstract string GetInput();

    /// <summary>
    /// Sends a response message to the user interface.
    /// </summary>
    public abstract void Respond(string message);

    /// <summary>
    /// Sends a response to the user interface with the provided exception details.
    /// </summary>
    public abstract void Respond(Exception exception);
}