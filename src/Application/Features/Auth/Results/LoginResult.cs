namespace Application.Features.Auth.Results;

public record LoginResult(string Id, string Username, string Email, string Token);