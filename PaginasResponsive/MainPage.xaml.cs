using PaginasResponsive.Resources.Localization;

namespace PaginasResponsive;

public partial class MainPage : ContentPage
{
    private IDispatcherTimer? languageTimer;
    private (string Language, bool Landscape)? appliedConfiguration;
    private Window? observedWindow;

    public MainPage()
    {
        InitializeComponent();
        SizeChanged += (_, _) => UpdateResources();
        UpdateResources();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        observedWindow = Window;
        if (observedWindow is not null)
            observedWindow.Resumed += OnResumed;

        // MAUI no tiene un evento común de cambio de idioma para todas las plataformas.
        languageTimer ??= Dispatcher.CreateTimer();
        languageTimer.Interval = TimeSpan.FromSeconds(1);
        languageTimer.Tick -= OnLanguageTick;
        languageTimer.Tick += OnLanguageTick;
        languageTimer.Start();
        UpdateResources();
    }

    protected override void OnDisappearing()
    {
        languageTimer?.Stop();
        if (observedWindow is not null)
            observedWindow.Resumed -= OnResumed;
        observedWindow = null;
        base.OnDisappearing();
    }

    private void OnResumed(object? sender, EventArgs e) => UpdateResources();
    private void OnLanguageTick(object? sender, EventArgs e) => UpdateResources();

    private void UpdateResources()
    {
        // El tamaño de la vista permite también previsualizar en ventanas de escritorio.
        var configuration = (Language: GreetingResources.GetDeviceLanguage(),
            Landscape: Width > Height && Height > 0);
        if (appliedConfiguration == configuration)
            return;

        var greeting = GreetingResources.Get(configuration.Language, configuration.Landscape);
        Resources["Saludo"] = greeting.Text;
        Resources["texto_saludo"] = greeting.TextColor;
        Resources["fondo_pantalla"] = greeting.BackgroundColor;
        appliedConfiguration = configuration;
    }
}
