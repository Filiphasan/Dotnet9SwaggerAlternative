using Api.Models;
using Api.Providers;

namespace Api;

public static class DependencyInjection
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<UserDataProvider>();

        var jwtSettings = configuration.GetSection(JwtSettingModel.Section).Get<JwtSettingModel>();
        ArgumentNullException.ThrowIfNull(jwtSettings);
        services.AddSingleton(jwtSettings);
    }
}