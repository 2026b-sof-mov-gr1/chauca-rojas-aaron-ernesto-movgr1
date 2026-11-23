using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.View;

namespace ExamenMovB1
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Fondo blanco en las pantallas: íconos oscuros en la barra de estado y navegación.
            if (Window?.DecorView is { } decor
                && WindowCompat.GetInsetsController(Window, decor) is { } controller)
            {
                controller.AppearanceLightStatusBars = true;
                controller.AppearanceLightNavigationBars = true;
            }
        }
    }
}
