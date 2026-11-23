using Microsoft.Extensions.Logging;

namespace ExamenMovB1
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

            // Quita la línea inferior que Android dibuja en Picker, Entry, Editor y SearchBar.
            Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("SinLinea", (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.Background = null;
#endif
            });
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("SinLinea", (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.Background = null;
#endif
            });
            Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping("SinLinea", (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.Background = null;
#endif
            });
            Microsoft.Maui.Handlers.SearchBarHandler.Mapper.AppendToMapping("SinLinea", (handler, view) =>
            {
#if ANDROID
                var vista = handler.PlatformView;
                var idPlate = vista.Resources?.GetIdentifier("search_plate", "id", vista.Context?.PackageName) ?? 0;
                if (idPlate != 0 && vista.FindViewById(idPlate) is { } plate)
                    plate.Background = null;
#endif
            });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
