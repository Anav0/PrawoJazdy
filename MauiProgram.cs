using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using PrawoJazdy.ViewModels;
using PrawoJazdy.Pages;

namespace PrawoJazdy;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<CategorySelectionPage>();
		builder.Services.AddSingleton<CategorySelectionViewModel>();
		builder.Services.AddTransient<QuizPage>();
		builder.Services.AddTransient<QuizViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
