using C___.DTOs.Post;
using C___.Models;

namespace C___.Repositorys.Interface
{
    public interface IPostRepository
    {
        public Post createPost(Post post, string username);

        public List<PostGetResponse> getPosts();

        public Post deletePost(string title, string username);

        public PostGetResponse getPostByTitle(string title);

        public List<PostGetResponse> getPostByCategory(string category);

        public Post updatePost(string title, string username, Post post);

        
    }
}
