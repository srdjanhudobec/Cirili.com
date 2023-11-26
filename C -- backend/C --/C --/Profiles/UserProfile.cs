using AutoMapper;
using C___.DTOs.User;
using C___.Models;

namespace C___.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserPostRequest>();
            CreateMap<UserPostRequest, User>();
            CreateMap<User, UserPostResponse>();
            CreateMap<UserPostResponse, User>();
            CreateMap<User, UserGetResponse>();
            CreateMap<UserGetResponse, User>();
        }
    }
}
