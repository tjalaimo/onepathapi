using onepathapi.Data;
using onepathapi.Models;
using Microsoft.EntityFrameworkCore;

namespace onepathapi.Services
{
    public interface IPostService
    {
        Task<Post> GetPost(int postId);
        Task<IEnumerable<Post>> GetPosts();
        Task<IEnumerable<Post>> GetUserPosts(int userId);
        Task<Post> CreatePost(Post newPost);
    }

    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Post> GetPost(int postId)
        {
            return await _context.Posts.Where(p => p.PostId == postId).FirstAsync();
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            int skip = 0;
            int take = 1000;
            return await _context.Posts.Skip(skip).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetUserPosts(int userId)
        {
            return await _context.Posts.Where(p => p.CreatedByUserId == userId).ToListAsync();
        }

        public async Task<Post> CreatePost(Post newPost)
        {
            _context.Posts.Add(newPost);
            newPost.PostId = await _context.SaveChangesAsync();
            return newPost;
        }
    }
}
