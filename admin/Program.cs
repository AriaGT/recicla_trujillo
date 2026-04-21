using admin.Views;
using admin.Services;
using admin.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using shared;
using shared.Services;

namespace admin;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        var builder = Host.CreateApplicationBuilder();

        builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);
        builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

        builder.Services.AddHttpClient<ApiClient>((serviceProvider, httpClient) =>
        {
            var settings = serviceProvider.GetRequiredService<IOptions<ApiSettings>>().Value;

            if (string.IsNullOrWhiteSpace(settings.BaseUrl))
                throw new InvalidOperationException("No se configuró ApiSettings:BaseUrl en appsettings.json");

            httpClient.BaseAddress = new Uri(settings.BaseUrl);
        });

        builder.Services.AddSingleton<ISessionService, SessionService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();

        builder.Services.AddSingleton<MainContainer>();

        builder.Services.AddTransient<LoginView>();
        builder.Services.AddTransient<HomeView>();
        builder.Services.AddTransient<DeliveriesView>();
        builder.Services.AddTransient<RegisterDeliveryView>();
        builder.Services.AddTransient<RewardsView>();
        builder.Services.AddTransient<RegisterRewardView>();
        builder.Services.AddTransient<RedemptionsView>();
        builder.Services.AddTransient<UsersView>();
        builder.Services.AddTransient<RegisterUserView>();

        using var host = builder.Build();

        var navService = (NavigationService)host.Services.GetRequiredService<INavigationService>();
        var mainForm = host.Services.GetRequiredService<MainContainer>();

        navService.Initialize(mainForm);

        Application.Run(mainForm);
    }
}