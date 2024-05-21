using Microsoft.EntityFrameworkCore;
namespace _924_server.Entities
{
    [PrimaryKey(nameof(Id))]
    public class Chat
    {
        public int Id { get; set; }

        public int NumberParticipants { get; set; } = 10;
    }
}
