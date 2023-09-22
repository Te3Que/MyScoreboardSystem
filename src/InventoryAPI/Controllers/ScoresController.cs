using Microsoft.AspNetCore.Mvc;
using InventoryAPI.Models;
using InventoryAPI.Services;

namespace InventoryAPI.Controllers;

[Controller]
[Route("api/[Controller]")]
public class ScoresController : Controller
{
    private readonly MongoDBService _mongoDBService;

    Scores updateScores = new Scores();

    public ScoresController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;

    }

    //  Crud functions

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Scores score) 
    {
        await _mongoDBService.CreateAsync(score);
        return CreatedAtAction(nameof(Get), new { _id = score._id }, score);
    }

    [HttpGet]
    public async Task<List<Scores>> Get()
    {
            return await _mongoDBService.GetAsync();
    }

    [HttpPut("{_id}")]
    public async Task<IActionResult> AddToScores(string _id, [FromBody] Scores updateScores)
    {
        await _mongoDBService.AddToScoresAsync(_id, updateScores);
        return NoContent();
    }

    [HttpDelete("{_id}")]
    public async Task<IActionResult> Delete(string _id)
    {
        await _mongoDBService.DeleteAsync(_id);
        return NoContent();
    }
    
}