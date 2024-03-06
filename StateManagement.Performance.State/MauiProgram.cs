using BlazorState;
using Microsoft.Extensions.Logging;
using StateManagement.Performance.Models.Services;
using System.Reflection;

namespace StateManagement.Performance.State;
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
            });
        
        builder.Services.AddBlazorState
        (
            options =>
                options.Assemblies =
                new Assembly[]
                {
                               typeof(MauiProgram).GetTypeInfo().Assembly,
                }
        );

        builder.Services.AddMauiBlazorWebView();

        builder.Services.AddScoped(typeof(ILoadDataService), typeof(LoadDataService));
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
