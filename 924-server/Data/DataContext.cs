
using _924_server.Entities;
using Microsoft.EntityFrameworkCore;

namespace _924_server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Message> Messages { get; set; } = null!;
    public DbSet<Chat> Chats { get; set; } = null!;
    public DbSet<Interest> Interests { get; set; } = null!;
    public DbSet<MapLocation> MapLocations { get; set; } = null!;
    public DbSet<Request> Requests { get; set; } = null!;
    public DbSet<UserChat> UserChats { get; set; } = null!;
    public DbSet<UserInterest> UserInterests { get; set; } = null!;
}