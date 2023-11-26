using AutoMapper;
using C___.DTOs.Post;
using C___.Models;

namespace C___.Profiles
{
    public class PostProfile:Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostPostRequest>();
            CreateMap<PostPostRequest, Post>();
            CreateMap<PostPostResponse, Post>();
            CreateMap<Post, PostPostResponse>();
            CreateMap<Post, PostGetResponse>();
            CreateMap<PostGetResponse, Post>();
            CreateMap<PostPutRequest, Post>();
            CreateMap<Post, PostPutRequest>();
            CreateMap<PostPutResponse, Post>();
            CreateMap<Post,PostPutResponse>();
        }
    }
}
