using Microsoft.Extensions.Logging;
using OpenAINetMaui.Services;
using OpenAINetMaui.ViewModels;
using OpenAINetMaui.Views;

namespace OpenAINetMaui;

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

		builder.Services.AddSingleton<IOpenAIService, OpenAIService>();

		builder.Services.AddTransient<ChatViewModel>();
		builder.Services.AddTransient<ChatView>();
		builder.Services.AddTransient<ImageViewModel>();
		builder.Services.AddTransient<ImageView>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
