using EventService.Data;
using EventService.Models;
using Microsoft.EntityFrameworkCore;

namespace EventService.Services;
//koden skriven i samarbete med Chatgpt
public class EventServiceHandler
{
    private readonly AppDbContext _context;
    public EventServiceHandler(AppDbContext context)
    {
        _context = context;
    }
    //Visa alla event
    public async Task<List<Event>> GetAllEventsAsync()
    {
        return await _context.Events.ToListAsync();
    }
    //Visa ett event via ID
    public async Task<Event?> GetByIdAsync(int id)
    {
        return await _context.Events.FindAsync(id);
    }

    public async Task<Event> CreateEventAsync(Event newEvent)
    {
        _context.Events.Add(newEvent);
        await _context.SaveChangesAsync();
        return newEvent;
    }
}
