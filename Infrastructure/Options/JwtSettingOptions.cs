namespace JwtAuthentification.Infrastructure.Options;

public class JwtSettingOptions
{
    public const string JwtSetting = "JwtSetting";

    public string Secret { get; set; } = string.Empty;
}

