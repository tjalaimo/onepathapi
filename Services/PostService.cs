using Microsoft.EntityFrameworkCore;
using onepathapi.Data;
using onepathapi.Models;
using onepathapi.DTOs;

namespace onepathapi.Services
{
    public interface IPostService
    {
        Task<PostDTO> GetPost(int postId);
        Task<(List<PostDTO>, int)> GetPosts(PaginationRequest request);
        Task<IEnumerable<PostDTO>> GetUserPosts(int userId);
        Task<PostDTO> CreatePost(Post newPost);
    }

    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PostDTO> GetPost(int postId)
        {
            Post post = await _context.Posts
                .Include(p => p.CreatedByUser)
                .Include(p => p.Comments)
                    .ThenInclude(c => c.CommentedByUser)
                .Include(p => p.Likes)
                    .ThenInclude(l => l.LikedByUser) 
                .Where(p => p.PostId == postId).FirstAsync();

            return new PostDTO(post);
        }

        public async Task<(List<PostDTO>, int)> GetPosts(PaginationRequest request)
        {
            var query = _context.Posts.AsQueryable();

            // If searchTerm is provided, apply the filters
            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                query = query.Where(p => p.Content.Contains(request.SearchTerm));
            }

            // Apply pagination
            var totalPosts = await query.CountAsync();
            var posts = await query
                .Include(p => p.CreatedByUser)
                .Include(p => p.Comments)
                    .ThenInclude(c => c.CommentedByUser)
                .Include(p => p.Likes)
                    .ThenInclude(l => l.LikedByUser)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return (posts.Select(p => new PostDTO(p)).ToList(), totalPosts);
        }

        public async Task<IEnumerable<PostDTO>> GetUserPosts(int userId)
        {
            IEnumerable<Post> posts = await _context.Posts
                .Include(p => p.CreatedByUser)
                .Include(p => p.Comments)
                    .ThenInclude(c => c.CommentedByUser)
                .Include(p => p.Likes)
                    .ThenInclude(l => l.LikedByUser)
                .Where(p => p.CreatedByUserId == userId).ToListAsync();

            return posts.Select(p => new PostDTO(p)).ToList();
        }

        public async Task<PostDTO> CreatePost(Post newPost)
        {
            _context.Posts.Add(newPost);
            newPost.PostId = await _context.SaveChangesAsync();
            return new PostDTO(newPost);
        }
    }
}
