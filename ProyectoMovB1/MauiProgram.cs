using Microsoft.Extensions.Logging;

namespace ProyectoMovB1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Quita la línea inferior que Android dibuja en los Picker.
            Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("SinLinea", (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.Background = null;
#endif
            });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
