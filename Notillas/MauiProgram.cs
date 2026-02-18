using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.Logging;
using Notillas.Services;
using Notillas.ViewModels;
using Notillas.Views;

namespace Notillas;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>();

        builder.Services.AddSingleton<NoteService>();
        builder.Services.AddSingleton<NotesViewModel>();
        builder.Services.AddSingleton<MainPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        var app = builder.Build();
        Ioc.Default.ConfigureServices(app.Services);
        return app;
    }
}
