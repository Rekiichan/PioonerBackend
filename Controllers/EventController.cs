using Microsoft.AspNetCore.Mvc;
using Pioneer_Backend.Service;
using Pioneer_Backend.Model.UpsertModel;
using Pioneer_Backend.Model;

namespace Pioneer_Backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class EventController : ControllerBase
{
    private readonly EventService _eventService;
    public EventController(EventService context)
    {
        _eventService = context;
    }

    [HttpGet]
    public async Task<List<Event>> Get()
    {
        return await _eventService.GetAsyncAllEvents();
    }

    [HttpGet("{NameId}")]
    public async Task<IActionResult> GetEventById(string id)
    {
        var obj = await _eventService.GetAsyncEventById(id);
        if (obj == null)
        {
            return NotFound();
        }
        return Ok(obj);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddEvent(EventUpsert newEvent)
    {
        var obj = new Event()
        {
            EventName= newEvent.EventName,
            EventDate=newEvent.EventDate,
            ImageUrl=newEvent.ImageUrl,
            Description=newEvent.Description,
        };

        await _eventService.CreateAsync(obj);
        return CreatedAtAction("GetEventById", new { id = obj.EventId}, obj);
    }

    [HttpPut("{NameId}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateEvent(Event eventRequest, string id)
    {
        var obj = await _eventService.GetAsyncEventById(id);
        if (obj == null) return NotFound();
        eventRequest.EventId = obj.EventId;
        await _eventService.UpdateAsync(id, eventRequest);
        return NoContent();
    }
    [HttpDelete("{NameId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteReward(string id)
    {
        var obj = await _eventService.GetAsyncEventById(id);
        if (obj == null)
        {
            return NotFound();
        }
        await _eventService.RemoveAsync(id);
        return NoContent();
    }
}