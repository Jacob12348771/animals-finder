using MonkeyFinder.Services;
using MonkeyFinder.View;

namespace MonkeyFinder;

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

		// Dependancy service knows to add page and all of its dependencies.

		builder.Services.AddSingleton<MonkeyService>();

        builder.Services.AddSingleton<MonkeysViewModel>();
        
        builder.Services.AddSingleton<MainPage>();

		return builder.Build();
	}
}
