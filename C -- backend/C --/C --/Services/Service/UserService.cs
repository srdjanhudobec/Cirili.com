using AutoMapper;
using C___.DTOs.User;
using C___.Models;
using C___.Repositorys.Interface;
using C___.Services.Interface;

namespace C___.Services.Service
{
    public class UserService:IUserService
    {
        public readonly IUserRepository _users;
        public readonly IMapper _mapper;

        public UserService(IUserRepository users, IMapper mapper)
        {
            _users = users;
            _mapper = mapper;
        }
        public UserPostResponse createUser(UserPostRequest user)
        {
            var response = _mapper.Map<UserPostResponse>(_users.createUser(_mapper.Map<User>(user)));
            if (response == null)
            {
                return null;
            }
            return response;
        }

        public List<UserGetResponse> getAllUsers()
        {
            var response = _mapper.Map<List<UserGetResponse>>(_users.getAllUsers());
            if (response == null)
            {
                return null;
            }
            return response;
        }
    }
}
