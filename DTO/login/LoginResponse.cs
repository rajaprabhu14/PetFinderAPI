namespace PetFinder.DTO.login;

public class LoginResponse
{
    public string Result { get; set; } = string.Empty;

    public bool IsLoggedIn { get; set; } = false;
}
