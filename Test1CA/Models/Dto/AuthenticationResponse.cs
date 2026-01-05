namespace Test1CA.Models.Dto;

public record AuthenticationResponse(Guid UserId, string? UserName, string? Email, string? Role, string? Token);
