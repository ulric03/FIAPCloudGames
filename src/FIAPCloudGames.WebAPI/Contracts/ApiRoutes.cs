namespace FIAPCloudGames.WebAPI.Contracts;

public static class ApiRoutes
{
    public static class Authentication
    {
        public const string Login = "authentication/login";
    }

    public static class Users
    {
        public const string Create = "users";
        
        public const string Update = "users/{userId:int}";

        public const string GetAll = "users";

        public const string GetById = "users/{userId:int}";

        public const string Active = "users/{userId:int}/active";

        public const string Inactive = "users/{userId:int}/inactive";
    }

}
