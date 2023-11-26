using C___.DTOs.User;

namespace C___.Services.Interface
{
    public interface IUserService
    {
        public UserPostResponse createUser(UserPostRequest user);

        public List<UserGetResponse> getAllUsers();
    }
}
