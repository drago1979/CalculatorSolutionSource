using Shared.Localization.Enum;
using Shared.Localization.Shared;

namespace Shared.Localization.Factory;

public class UserMessagesFactoryDictionaryBased : IUserMessagesFactory
{
    public UserMessages Create(Language lang)
    {
        return lang.Create();
    }
}