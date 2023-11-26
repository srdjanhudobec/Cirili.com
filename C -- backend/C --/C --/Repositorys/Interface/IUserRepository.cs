using C___.Models;

namespace C___.Repositorys.Interface
{
    public interface IUserRepository
    {
        public User createUser(User user);

        public List<User> getAllUsers();
    }
}
