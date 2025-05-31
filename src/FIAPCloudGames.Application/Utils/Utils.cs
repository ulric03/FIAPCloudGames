namespace FIAPCloudGames.Application.Utils;

public static class Utils
{
    public static string HashPassword(string password)
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes(password);
        var hash = System.Security.Cryptography.SHA256.HashData(bytes);
        return Convert.ToBase64String(hash);
    }
}
