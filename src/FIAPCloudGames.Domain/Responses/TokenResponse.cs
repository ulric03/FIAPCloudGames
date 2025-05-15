namespace FIAPCloudGames.Domain.Responses;

public sealed class TokenResponse
{
    public TokenResponse(string token) => Token = token;

    public string Token { get; }
}
