using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;

namespace _924_server.Entities
{
    [PrimaryKey(nameof(UserId), nameof(ChatId))]
    public class UserChat
    {
        public int UserId { get; set; }

        public int ChatId { get; set; }
    }
}
