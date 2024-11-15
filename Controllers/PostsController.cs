using Microsoft.AspNetCore.Mvc;
using onepathapi.Models;
using onepathapi.Services;
using onepathapi.DTOs;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostService _postService;

    public PostsController(IPostService postService)
    {
        _postService = postService;
    }    

    [HttpGet("getPost")]
    public async Task<IActionResult> getPost(int postId)
    {
        PostDTO post = await _postService.GetPost(postId);
        if (post != null)
        {
            return Ok(post);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost("getPosts")]
    public async Task<IActionResult> getPosts([FromBody] PaginationRequest request)
    {
        var (posts, totalPosts) = await _postService.GetPosts(request);
        var result = new
        {
            TotalCount = totalPosts,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            Posts = posts
        };

        return Ok(result);
    }

    [HttpGet("getUserPosts")]
    public async Task<IActionResult> getUserPosts(int userId)
    {
        IEnumerable<PostDTO> posts = await  _postService.GetUserPosts(userId);
        return Ok(posts);
    }

    [HttpPost("createPost")]
    public async Task<IActionResult> createPost(Post newPost)
    {
        var post = await _postService.CreatePost(newPost);
        return Ok(post);
    }
}
