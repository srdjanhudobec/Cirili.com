using C___.Data;
using C___.Models;
using C___.Repositorys.Interface;

namespace C___.Repositorys.Repository
{
    public class UserRepository:IUserRepository
    {
        public readonly DatabaseContext _context;
        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public UserRepository() { }

        public User createUser(User user)
        {
            if (user != null)
            {
                _context.Add(user);
                _context.SaveChanges();
                return user;
            }
            return null;
        }

        public List<User> getAllUsers()
        {
            return _context.users.ToList();
        }
    }
}
