namespace BookManager.BusinessObjects.DTOs.Login
{
    public record struct UserDto(
        string UserName,
        string Email
        );
}
