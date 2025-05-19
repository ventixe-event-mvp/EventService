using EventService.Models;
using Microsoft.EntityFrameworkCore;

namespace EventService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
     public DbSet<Event> Events { get; set; } = null!;
};

    
