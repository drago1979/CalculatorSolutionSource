using Shared.Localization.Enum;

namespace Shared.Helpers;

public static class Helper
{
    public static bool TryGetValidEnum<T>(string input, out T value) where T : struct, Enum
    {
        if (Enum.TryParse<T>(input, true, out value) && Enum.IsDefined<T>(value)) return true;
      
        value = default;

        return false;
    }
}