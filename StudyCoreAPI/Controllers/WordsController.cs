using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudyCoreAPI.Application.DTOs;
using StudyCoreAPI.Application.Interfaces;

namespace StudyCoreAPI.Controllers;

[ApiController]
[Route("workspace/{workspaceId}/words")]
[Authorize]
public class WordsController : ControllerBase
{
    private readonly IWordService _wordService;
    private readonly ILogger<WordsController> _logger;
    
    public WordsController(IWordService wordService, ILogger<WordsController> logger)
    {
        _wordService = wordService;
        _logger = logger;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetWords([FromRoute] Guid workspaceId)
    {
        try
        {
            _logger.LogInformation("Getting words for workspace {WorkspaceId}", workspaceId);
            var allWords = await _wordService.GetAllByWorkspaceId(workspaceId);
            return Ok(allWords);
        }
        catch (KeyNotFoundException ex)
        {
            _logger.LogWarning(ex, "Workspace {WorkspaceId} not found", workspaceId);
            return NotFound(ex.Message);
        }
    }
    
    [HttpGet("{wordId}")]
    public async Task<IActionResult> GetWordsById(int wordId)
    {
        var word = await _wordService.GetByIdAsync(wordId);

        if (word == null)
            return NotFound();
        
        return Ok(word);
    }

    [HttpPost]
    public async Task<IActionResult> AddWord([FromRoute] Guid workspaceId, WordCreateDto request)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var wordRequest = new WordCreateDto()
        {
            OwnerId = userId,
            Name = request.Name,
            Note = request.Name,
            PartOfSpeech = request.PartOfSpeech,
            Meaning = request.Meaning,
            Level = request.Level,
            Type = request.Level
        };

        await _wordService.AddAsync(workspaceId, wordRequest);
        return Ok();
    }
    
    [HttpDelete("{wordId}")]
    public async Task<IActionResult> DeleteWord(int wordId)
    {
        var existingWord = await _wordService.GetByIdAsync(wordId);
    
        if (existingWord == null)
            return NotFound();

        await _wordService.DeleteAsync(wordId);
        return NoContent();
    }
    
    [HttpPatch("{wordId}")]
    public async Task<IActionResult> UpdateWord([FromRoute] int wordId, [FromBody] WordUpdateDto wordDto)
    {
        var existingWord = await _wordService.GetByIdAsync(wordId);
        
        if (existingWord == null)
            return NotFound(); 

        await _wordService.UpdateAsync(wordId, wordDto);

        return NoContent();
    }
}