namespace BookManager.Cross.Entities.Interfaces
{
    public interface IUserService
    {
        bool IsAuthenticated { get; }
        string UserName { get; }
    }
}
