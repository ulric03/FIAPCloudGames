using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCloudGames.Domain.Responses;

public sealed class TokenResponse
{
    public TokenResponse(string token, bool authenticated)
    { 
        Token = token;
        Authenticated = authenticated;
    }
    
    public string Token { get; }

    public bool Authenticated { get; }
}
