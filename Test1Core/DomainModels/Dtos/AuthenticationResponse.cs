namespace Test1Core.DomainModels.Dtos;

public record AuthenticationResponse(Guid UserId, string? UserName, string? Email, string? Role, string? Token,bool? Status)
{
    public AuthenticationResponse() : this(default, default, default, default, default, default) { }
}

