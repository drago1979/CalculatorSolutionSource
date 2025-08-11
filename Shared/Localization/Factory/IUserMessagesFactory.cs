using Shared.Localization.Enum;
using Shared.Localization.Shared;

namespace Shared.Localization.Factory;

///
public interface IUserMessagesFactory
{
    ///
    public UserMessages Create(Language lang);
}