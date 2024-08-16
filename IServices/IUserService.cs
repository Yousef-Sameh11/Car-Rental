namespace CarRentalSystem.IServices
{
    public interface IUserService
    {
        Task GetAllUsers();
        Task GetUserById(int id);

        Task DeleteUser(int id);

    }
}
