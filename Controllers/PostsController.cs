using Microsoft.AspNetCore.Mvc;
using onepathapi.Models;
using onepathapi.Services;

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
        Post post = await _postService.GetPost(postId);
        if (post != null)
        {
            return Ok(post);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpGet("getPosts")]
    public async Task<IActionResult> getPosts()
    {
        IEnumerable<Post> posts = await _postService.GetPosts();
        return Ok(posts);
    }

    [HttpGet("getUserPosts")]
    public async Task<IActionResult> getUserPosts(int userId)
    {
        IEnumerable<Post> posts = await  _postService.GetUserPosts(userId);
        return Ok(posts);
    }

    [HttpPost("createPost")]
    public async Task<IActionResult> createPost(Post newPost)
    {
        var post = await _postService.CreatePost(newPost);
        return Ok(post);
    }
}
