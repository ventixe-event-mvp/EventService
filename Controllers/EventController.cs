﻿using EventService.Models;
using EventService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventService.Controllers;
// koden skriven i samarbete med Chatgpt
[Route("api/[controller]")]
[ApiController]
public class EventController : ControllerBase
{
    private readonly EventServiceHandler _eventService;

    public EventController(EventServiceHandler eventService)
    {
        _eventService = eventService;
 
    
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Event>>> GetAllEvents()
    {
        var events = await _eventService.GetAllEventsAsync();
        return Ok(events);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Event>> GetEventById(int id)
    {
       var entity = await _eventService.GetByIdAsync(id);
        if (entity == null)
        {
            return NotFound();
        }
        return Ok(entity);
    }

    [HttpPost]
    public async Task<ActionResult<Event>> CreateEvent([FromBody] Event newEvent)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = await _eventService.CreateEventAsync(newEvent);
        return Ok(created);
    }
}
