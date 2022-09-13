namespace FA22.P04.Web.Features.Authorization;

public class UserDto
{
    public int ID { get; set; }

    public string UserName { get; set; }

    public string[] Role { get; set; }
}