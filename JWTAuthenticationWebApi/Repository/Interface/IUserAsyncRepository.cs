using JWTAuthenticationWebApi.Model;

namespace JWTAuthenticationWebApi.Repository.Interface
{
    public interface IUserAsyncRepository
    {
        Task<int> AddNewUser(User user);
        Task<UserLogInModel> UserLogInRepostory(UserLogInModel user);
        Task<int> UpdateUser(User user);
        Task<List<User>> GetAllUsers(User user);
        Task<User> GetUserById(int Id);
        Task<int> DeleteUser(int Id);

    }
}
