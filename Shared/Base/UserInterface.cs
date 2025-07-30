namespace Shared.Base;

public abstract class UserInterface
{
    public abstract string GetInput();
    public abstract void Respond(string message);
    public abstract void Respond(Exception exception);
}