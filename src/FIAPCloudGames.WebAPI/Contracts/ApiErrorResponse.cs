
using FIAPCloudGames.Domain.Core;

namespace FIAPCloudGames.WebAPI.Contracts;

public class ApiErrorResponse
{
    public ApiErrorResponse(IReadOnlyCollection<Error> errors) 
        => Errors = errors;

    public IReadOnlyCollection<Error> Errors { get; }
}