namespace MAUIApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        var composition = new Composition();
        
        builder
            .UseMauiApp(_ => new App
            {
                // Overrides the resource with an initialized Composition instance
                Resources = { ["Composition"] = composition }
            })
            .ConfigureLifecycleEvents(events =>
            {
                // Handles disposables
#if WINDOWS
                events.AddWindows(windows => windows
                    .OnClosed((_, _) => { }));
#endif
#if ANDROID
                events.AddAndroid(android => android
                    .OnStop(_ => { }));
#endif
            })
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}