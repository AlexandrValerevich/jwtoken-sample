using Microsoft.AspNetCore.Mvc;

namespace JwtAuthentification.Contracts.V1;

public static class ApiRoutes
{
    public const string Root = "api";
    public const string Version = "v1";
    public const string Base = Root + "/" + "Version";

    public static class Identity
    {
        public const string Login = Base + "/identity/login";
        public const string Register = Base + "/identity/register";
    }
}