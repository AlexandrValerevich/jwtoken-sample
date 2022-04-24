using JwtAuthentification.Infrastructure.Options;

namespace JwtAuthentification.Infrastructure.Helpers;

public static class ConfigurationHelper
{
    public static JwtSettingOptions GetJwtSettingOptions(this IConfiguration configuration)
    {
        return configuration.GetJwtSettingSection().Get<JwtSettingOptions>();
    }

    public static IConfigurationSection GetJwtSettingSection(this IConfiguration configuration)
    {
        return configuration.GetSection(JwtSettingOptions.JwtSetting);
    }
}