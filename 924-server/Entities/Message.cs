using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _924_server.Entities;


[PrimaryKey(nameof(Id))]
public class Message
{
    public int Id { get; set; }

    public string Content { get; set; } = string.Empty;

    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;

    public int ChatId {  get; set; }
    [ForeignKey(nameof(ChatId))]
    public Chat Chat { get; set; } = null!;

    public DateTime SentTime { get; set; }
}