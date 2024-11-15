using Microsoft.AspNetCore.Mvc;
using onepathapi.Services;
using onepathapi.Models;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;

    public ChatController(IChatService chatService)
    {
        _chatService = chatService;
    }

    [HttpGet("getUserChats/{userId}")]
    public async Task<IActionResult> GetChats(int userId)
    {
        try
        {
            var threads = await _chatService.GetChats(userId);
            return Ok(threads);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("getChat/{chatId}")]
    public async Task<IActionResult> GetChat(int chatId)
    {
        try
        {
            var messages = await _chatService.GetChat(chatId);
            return Ok(messages);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendMessage(Message message)
    {
        if (message == null || string.IsNullOrEmpty(message.MessageContent))
        {
            return BadRequest("Message content is required.");
        }

        try
        {
            var result = await _chatService.SendMessage(message);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
