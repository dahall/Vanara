using Microsoft.UI.Xaml;
using System.Globalization;

namespace electrifier.Controls.Localization;

public sealed class LocalizationManager
{
    public static LocalizationManager Instance { get; } = new LocalizationManager();

    private LocalizationManager()
    {
    }

    public event EventHandler? LanguageChanged;

    public CultureInfo CurrentCulture { get; private set; } = CultureInfo.CurrentUICulture;

    public void ChangeCulture(string cultureName)
    {
        var culture = new CultureInfo(cultureName);

        if (Equals(culture, CurrentCulture))
            return;

        CurrentCulture = culture;
        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;

        ReloadResourceDictionary(culture);

        LanguageChanged?.Invoke(this, EventArgs.Empty);
    }

    private void ReloadResourceDictionary(CultureInfo culture)
    {
        // Annahme: du hast genau EIN Vanara‑Dictionary gemerged
        var app = (Application)Application.Current;

        var rd = app.Resources.MergedDictionaries
            .FirstOrDefault(d => d.Source != null &&
                                 d.Source.OriginalString.Contains("Resources/Vanara.WinUI.xaml"));

        if (rd == null)
            return;

        // Neutral (englisch)
        Uri newSource;

        if (culture.TwoLetterISOLanguageName.Equals("en", StringComparison.OrdinalIgnoreCase))
        {
            newSource = new Uri("ms-appx:///Resources/Vanara.WinUI.xaml");
        }
        else
        {
            // z.B. ms-appx:///Resources/de-DE/Vanara.WinUI.xaml
            newSource = new Uri($"ms-appx:///Resources/{culture.Name}/Vanara.WinUI.xaml");
        }

        rd.Source = newSource;
    }

    public string GetString(string key)
    {
        if (Application.Current.Resources.TryGetValue(key, out var value) &&
            value is string s)
        {
            return s;
        }

        // Fallback: Key anzeigen, damit man Fehler sieht
        return $"[{key}]";
    }
}
