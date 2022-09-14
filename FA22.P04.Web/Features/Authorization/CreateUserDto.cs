namespace FA22.P04.Web.Features.Users;

public class CreateUserDto
{
    public string? Username { get; set; }

    public string? Password { get; set; }

    public string[]? Role { get; set; }
}