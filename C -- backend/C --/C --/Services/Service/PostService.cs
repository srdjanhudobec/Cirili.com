using AutoMapper;
using C___.DTOs.Post;
using C___.Models;
using C___.Repositorys.Interface;
using C___.Services.Interface;

namespace C___.Services.Service
{
    public class PostService : IPostService
    {
        public readonly IPostRepository _posts;
        public readonly IMapper _mapper;
        public PostService(IPostRepository posts, IMapper mapper)
        {
            _posts = posts;
            _mapper = mapper;
        }

        public PostPostResponse createPost(PostPostRequest post, string username)
        {
            var response = _mapper.Map<PostPostResponse>(_posts.createPost(_mapper.Map<Post>(post), username));
            if (response == null)
            {
                return null;
            }
            return response;
        }

        public PostGetResponse deletePost(string title, string username)
        {
            var response = _mapper.Map<PostGetResponse>(_posts.deletePost(title, username));
            if (response == null)
            {
                return null;
            }
            return response;
        }

        public List<PostGetResponse> getPostByCategory(string category)
        {
            var response = _posts.getPostByCategory(category);
            if (response == null)
            {
                return null;
            }
            return response;
        }

        public PostGetResponse getPostByTitle(string title)
        {
            var response = _posts.getPostByTitle(title);
            if (response == null)
            {
                return null;
            }
            return response;
        }

        public List<PostGetResponse> getPosts()
        {
            var response = _posts.getPosts();
            if (response == null)
            {
                return null;
            }
            return response;
        }

        public PostPutResponse updatePost(string title, string username, PostPutRequest post)
        {
            var postBeforeConverting = _posts.updatePost(title,username,_mapper.Map<Post>(post));
            var response = _mapper.Map<PostPutResponse>(postBeforeConverting);
            if (response == null)
            {
                return null;
            }
            return response;
        }
    }
}
