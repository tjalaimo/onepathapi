using Microsoft.AspNetCore.Mvc;
using onepathapi.Services;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;

    public ChatController(IChatService chatService)
    {
        _chatService = chatService;
    }

    [HttpGet("{userId}")]
    public IActionResult GetChats(string userId)
    {
        var chats = _chatService.GetChats(userId);
        return Ok(chats);
    }

    [HttpPost("send")]
    public IActionResult SendMessage()
    {
        var result = _chatService.SendMessage();
        return Ok(new { Message = result });
    }
}
