using AutoMapper;
using C___.Data;
using C___.DTOs.Post;
using C___.Models;
using C___.Repositorys.Interface;

namespace C___.Repositorys.Repository
{
    public class PostRepository:IPostRepository
    {
        public readonly DatabaseContext _context;
        public readonly IMapper _mapper;

        public PostRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Post createPost(Post post, string username)
        {
            if (post.Category.ToLower().Equals("развој") == false && post.Category.ToLower().Equals("дизајн") == false && post.Category.ToLower().Equals("ресурси") == false && post.Category.ToLower().Equals("магазин") == false) {
                return null;
            }
            try
            {
                User u = _context.users.FirstOrDefault(x => x.Username == username);
                if (u != null)
                {
                    post.CreatorId = u.Id;
                }
                if (post != null)
                {
                    _context.posts.Add(post);
                    _context.SaveChanges();
                    return post;
                }
            }catch
            {
                return null;
            }
            return null;
        }

        public Post deletePost(string title, string username)
        {
            try
            {
                User u = _context.users.FirstOrDefault(x => x.Username == username);
                Post p = _context.posts.FirstOrDefault(c => c.Title == title);
                if (u != null && p != null)
                {
                    if (p.CreatorId != u.Id)
                    {
                        return null;
                    }
                }
                if (p != null)
                {
                    _context.posts.Remove(p);
                    _context.SaveChanges();
                    return p;
                }
                return null;

            }catch
            {
                return null;
            }
        }

        public List<PostGetResponse> getPostByCategory(string category)
        {
            List<PostGetResponse> newList = new List<PostGetResponse>();
            List<PostGetResponse> oldList = _mapper.Map<List<PostGetResponse>>(_context.posts);
            for (int i=0;i<oldList.Count();i++) {
                if (oldList[i].Category.Equals(category.ToLower())) {
                    newList.Add(oldList[i]);
                }
            }
            if (newList.Count > 0)
            {
                return _mapper.Map<List<PostGetResponse>>(newList);
            }
            return null;
        }

        public PostGetResponse getPostByTitle(string title)
        {
            Post p = _context.posts.FirstOrDefault(x => x.Title == title);
            if (p != null) {
                return _mapper.Map<PostGetResponse>(p);
            }   
            return null;
        }

        public List<PostGetResponse> getPosts()
        {
            List<Post> posts = _context.posts.ToList();
            List<PostGetResponse> convertedPosts = _mapper.Map<List<PostGetResponse>>(posts);
            return convertedPosts;
        }

        public Post updatePost(string title, string username, Post post)
        {
            try
            {
                User u = _context.users.FirstOrDefault(x => x.Username == username);
                Post p = _context.posts.FirstOrDefault(c => c.Title == title);
                if (u != null && p != null)
                {
                    if (p.CreatorId != u.Id)
                    {
                        return null;
                    }
                }
                if (p != null)
                {
                    p.Title = post.Title;
                    p.Content = post.Content;
                    _context.SaveChanges();
                    return p;
                }
                return null;

            }
            catch
            {
                return null;
            }
        }
    }
}
