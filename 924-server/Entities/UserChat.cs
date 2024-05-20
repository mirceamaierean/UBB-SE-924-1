using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;

namespace _924_server.Entities
{
    [PrimaryKey(nameof(UserId), nameof(ChatId))]
    public class UserChat
    {
        public User User { get; set; } = null!;
        public int UserId { get; set; }

        public Chat Chat { get; set; } = null!;
        public int ChatId { get; set; }
    }
}
