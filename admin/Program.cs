using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using shared;

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

        builder.Services.AddTransient<Form1>();
        builder.Services.AddTransient<HomeForm>();
        builder.Services.AddTransient<DeliveriesForm>();
        builder.Services.AddTransient<RewardsForm>();
        builder.Services.AddTransient<RedemptionFlowForm>();
        builder.Services.AddTransient<UserCreateForm>();

        using var host = builder.Build();
        var form = host.Services.GetRequiredService<Form1>();

        Application.Run(form);
    }
}