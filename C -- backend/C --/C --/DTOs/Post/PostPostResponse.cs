

namespace C___.DTOs.Post
{
    using C___.Models;
    public class PostPostResponse
    {
        public int CreatorId { get; set; }

        public User Creator { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

    }
}
