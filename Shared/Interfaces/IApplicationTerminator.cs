using Shared.Base;
using Shared.Localization.Shared;

namespace Shared.Interfaces;

public interface IApplicationTerminator
{
    public void Terminate(UserInterface userInterface, UserMessages userMessages);
}