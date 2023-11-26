using C___.DTOs.Post;

namespace C___.Services.Interface
{
    public interface IPostService
    {
        public PostPostResponse createPost(PostPostRequest post, string username);

        public List<PostGetResponse> getPosts();

        public PostGetResponse deletePost(string title, string username);

        public PostGetResponse getPostByTitle(string title);

        public List<PostGetResponse> getPostByCategory(string category);

        public PostPutResponse updatePost(string title, string username, PostPutRequest post);
    }
}
