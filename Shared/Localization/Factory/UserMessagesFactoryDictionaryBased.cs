using Shared.Localization.Enum;
using Shared.Localization.Shared;

namespace Shared.Localization.Factory;

/// <summary>
/// A factory implementation of <see cref="IUserMessagesFactory"/> that creates
/// <see cref="UserMessages"/> instances based on a specified <see cref="Language"/>
/// </summary>
public class UserMessagesFactoryDictionaryBased : IUserMessagesFactory
{
    /// <summary>
    /// Creates a new instance of <see cref="UserMessages"/> based on the specified <see cref="Language"/>.
    /// </summary>
    public UserMessages Create(Language lang)
    {
        return lang.Create();
    }
}