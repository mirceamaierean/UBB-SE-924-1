using Microsoft.EntityFrameworkCore;
namespace _924_server.Entities;

// Set the id as the primary key
[PrimaryKey(nameof(Id))]
public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}