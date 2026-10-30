using System.Globalization;
using System.Resources;

namespace PaginasResponsive.Resources.Localization;

internal static class GreetingResources
{
    private static readonly ResourceManager Manager = new(
        "PaginasResponsive.Resources.Localization.Greetings", typeof(GreetingResources).Assembly);

    internal static string GetDeviceLanguage()
    {
#if ANDROID
        var configuration = Android.App.Application.Context.Resources?.Configuration;
        string? language;
        if (OperatingSystem.IsAndroidVersionAtLeast(24))
        {
            var locales = configuration?.Locales;
            language = locales is not null && locales.Size() > 0 ? locales.Get(0)?.Language : null;
        }
        else
        {
#pragma warning disable CS0618
            language = configuration?.Locale?.Language;
#pragma warning restore CS0618
        }
#elif IOS || MACCATALYST
        var language = Foundation.NSLocale.PreferredLanguages.FirstOrDefault();
#elif WINDOWS
        var language = Windows.System.UserProfile.GlobalizationPreferences.Languages.FirstOrDefault();
#else
        var language = CultureInfo.CurrentUICulture.Name;
#endif
        return language?.Split('-', '_')[0].Equals("en", StringComparison.OrdinalIgnoreCase) == true
            ? "en" : "es";
    }

    internal static (string Text, Color TextColor, Color BackgroundColor) Get(string language, bool landscape)
    {
        var culture = CultureInfo.GetCultureInfo(language == "en" ? "en" : "es");
        var prefix = landscape ? "Landscape" : "Portrait";
        string Read(string suffix) => Manager.GetString($"{prefix}_{suffix}", culture)
            ?? throw new MissingManifestResourceException($"Falta {prefix}_{suffix}.");

        return (Read("Saludo"), Color.FromArgb(Read("texto_saludo")),
            Color.FromArgb(Read("fondo_pantalla")));
    }
}
