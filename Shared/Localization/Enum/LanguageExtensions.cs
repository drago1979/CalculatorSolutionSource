using Shared.Localization.Shared;

namespace Shared.Localization.Enum;

public static class LanguageExtensions
{
    static LanguageExtensions()
    {
        ValidateEnumCoverage();
    }
    
    private static void ValidateEnumCoverage()
    {
        var enumValues = System.Enum.GetValues<Language>();

        foreach (var lang in enumValues)
        {
            if (!Factories.ContainsKey(lang))
                throw new InvalidOperationException($"Missing factory mapping for Language.{lang}");

            if (!UserPreviews.ContainsKey(lang))
                throw new InvalidOperationException($"Missing user preview mapping for Language.{lang}");
        }
    }
    
    
    private static readonly Dictionary<Language, Func<UserMessages>> Factories = new()
    {
        [Language.En] = () => new UserMessagesEn(),
        [Language.SrbLat] = () => new UserMessagesSrbLat(),
    };

    private static readonly Dictionary<Language, string> UserPreviews = new()
    {
        [Language.En] = "English",
        [Language.SrbLat] = "Serbian Latin",
    };

    public static UserMessages Create(this Language lang) // todo: static?
    {
        return Factories[lang]();
    }

    public static string GetUserPreview(this Language lang)
    {
        return UserPreviews[lang];
    }
    public static string GetAllLanguages(this Language lang)
    {
        return string.Join(", ", System.Enum.GetValues<Language>());
    }
}