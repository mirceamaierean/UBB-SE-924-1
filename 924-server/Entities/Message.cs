namespace _924_server.Entities;

public class Message
{
    public int Id { get; set; }

    public string Content { get; set; } = string.Empty;

    public int UserId { get; set; }

    public User User { get; set; } = null!;

    public int ChatId {  get; set; }

    public Chat Chat { get; set; } = null!;

    public DateTime SentTime { get; set; }
}